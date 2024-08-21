using System;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components;

public class CategoriesViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;
    public CategoriesViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IViewComponentResult Invoke()
    {
        var categories = _serviceManager.CategoryService.GetAllCategories(false);
        return View(categories);

    }

}
