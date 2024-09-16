using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;

        public readonly Cart Cart;
        public string ReturnUrl { get; set; } = "/";


        public CartModel(IServiceManager manager, Cart card)
        {
            _manager = manager;
            Cart = card;
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
                Cart.AddProduct(product, 1);
            }

            return Page();
        }

        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetProduct(productId, false);

            if (product != null)
            {
                Cart.RemoveProductLine(product, 1);
            }

            return Page();
        }
    }
}
