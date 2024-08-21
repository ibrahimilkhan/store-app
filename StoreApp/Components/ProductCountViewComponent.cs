using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components;

public class ProductCountViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public ProductCountViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public string Invoke()
    {
        return _serviceManager.ProductService.GetAllProducts(false).Count().ToString();
    }
}