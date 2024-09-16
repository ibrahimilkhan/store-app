using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
    public class SessionDemoModel : PageModel
    {
        public string? Name => HttpContext.Session.GetString("name");
        public void OnGet()
        {
        }

        public void OnPost(string name)
        {
            HttpContext.Session.SetString("name", name);
        }
    }
}