using System;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components;

public class ProductFilterMenuViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public ProductFilterMenuViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IViewComponentResult Invoke()
    {
        return View();
    }
}
