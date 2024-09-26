using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace StoreApp.Components;

public class ShowcaseViewComponent : ViewComponent
{
    private readonly IServiceManager _manager;

    public ShowcaseViewComponent(IServiceManager manager)
    {
        _manager = manager;
    }

    public IViewComponentResult Invoke()
    {
        var products = _manager.ProductService.GetShowcaseProduct(false);
        return View(products);
    }
}