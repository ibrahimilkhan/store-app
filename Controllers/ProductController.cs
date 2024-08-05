using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;


namespace StoreApp.Controllers;
public class ProductController : Controller
{
    private readonly RepositoryContext _context;

    public ProductController(RepositoryContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var model = _context.Products.ToList();
        return View(model);
    }

    public IActionResult Get(int id)
    {
        var model = _context.Products.FirstOrDefault(x => x.Id == id);
        return View(model);
    }
}