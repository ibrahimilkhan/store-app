using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";


        public CartModel(IServiceManager manager, Cart cartService)
        {
            _manager = manager;
            Cart = cartService;

        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPostAdd(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetProduct(productId, false);

            if (product != null)
            {
                Cart.AddItem(product, 1);
            }

            return RedirectToPage(new { returnUrl });
        }

        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetProduct(productId, false);

            if (product != null)
            {
                Cart.RemoveLine(product);
            }

            return Page();
        }
    }
}