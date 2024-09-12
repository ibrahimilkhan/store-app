using System;
using System.Diagnostics;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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
        var products = _manager.ProductService.GetAllProducts(false);
        return View(products);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm] Product product)
    {
        if (ModelState.IsValid)
        {
            _manager.ProductService.CreateProduct(product);
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Update([FromRoute(Name = "id")] int id)
    {
        var product = _manager.ProductService.GetProduct(id, false);

        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Product product)
    {
        if (!ModelState.IsValid)
            return View();

        _manager.ProductService.UpdateOneProduct(product);
        return RedirectToAction("Index");
    }


    public IActionResult Delete([FromRoute(Name = "id")] int id)
    {
        _manager.ProductService.DeleteProduct(id);
        return RedirectToAction("Index");
    }
}