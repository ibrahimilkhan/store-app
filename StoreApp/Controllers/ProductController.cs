using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers;
public class ProductController : Controller
{
    private readonly IServiceManager _serviceManager;
    public ProductController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IActionResult Index()
    {
        var model = _serviceManager.ProductService.GetAllProducts(false).ToList();
        return View(model);
    }

    public IActionResult Get(int id)
    {
        var product = _serviceManager.ProductService.GetProduct(id, false);
        return View(product);
    }
}