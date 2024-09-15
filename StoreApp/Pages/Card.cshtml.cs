using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CardModel : PageModel
    {
        private readonly IServiceManager _manager;

        public Card Card { get; set; }
        public string ReturnUrl { get; set; } = "/";


        public CardModel(IServiceManager manager)
        {
            _manager = manager;
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
                Card.AddProduct(product, 1);
            }

            return Page();
        }

        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetProduct(productId, false);

            if (product != null)
            {
                Card.RemoveProductLine(product, 1);
            }

            return Page();
        }
    }
}
