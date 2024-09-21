
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IServiceManager _manager;

    public ProductController(IServiceManager manager)
    {
        _manager = manager;
    }

    public ViewResult Index()
    {
        var products = _manager.ProductService.GetAllProductDtosForView(false);
        return View(products);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = GetCategorySelectList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion product, IFormFile file)
    {
        if (ModelState.IsValid)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            product.ImageUrl = string.Concat("/images/", file.FileName);

            _manager.ProductService.CreateProduct(product);
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Update([FromRoute(Name = "id")] int id)
    {
        ViewBag.Categories = GetCategorySelectList();
        var product = _manager.ProductService.GetProductDtoForUpdate(id, false);

        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate product, IFormFile file)
    {
        if (file != null)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            product.ImageUrl = string.Concat("/images/", file.FileName);
        }

        ModelState.Remove("file");
        if (!ModelState.IsValid)
        {
            return View();
        }

        _manager.ProductService.UpdateOneProduct(product);
        return RedirectToAction("Index");
    }


    public IActionResult Delete([FromRoute(Name = "id")] int id)
    {
        _manager.ProductService.DeleteProduct(id);
        return RedirectToAction("Index");
    }

    private SelectList GetCategorySelectList()
    {
        var categories = _manager.CategoryService.GetAllCategories(false);
        return new SelectList(categories, "Id", "Name", 1); ;
    }
}