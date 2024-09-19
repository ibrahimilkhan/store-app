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

        public required Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";


        public CartModel(IServiceManager manager)
        {
            _manager = manager;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPostAdd(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetProduct(productId, false);

            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddProduct(product, 1);

                HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage(new { returnUrl });
        }

        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetProduct(productId, false);

            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.RemoveProductLine(product, 1);

                HttpContext.Session.SetJson("cart", Cart);
            }

            return Page();
        }
    }
}
