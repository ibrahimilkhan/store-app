using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: CategoryController
        public IActionResult Index()
        {
            var models = _serviceManager.CategoryService.GetAllCategories(false);
            return View(models);
        }
    }
}