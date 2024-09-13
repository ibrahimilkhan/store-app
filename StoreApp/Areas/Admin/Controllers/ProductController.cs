using System;
using System.Diagnostics;
using Entities.Dtos;
using Entities.Models;
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
    public IActionResult Create([FromForm] ProductDtoForInsertion product)
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
        ViewBag.Categories = GetCategorySelectList();
        var product = _manager.ProductService.GetProductDtoForUpdate(id, false);

        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update([FromForm] ProductDtoForUpdate product)
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

        private SelectList GetCategorySelectList()
    {
        var categories = _manager.CategoryService.GetAllCategories(false);
        return new SelectList(categories, "Id", "Name", 1); ;
    }
}