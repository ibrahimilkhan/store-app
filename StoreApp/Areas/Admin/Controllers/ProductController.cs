using System;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    public ViewResult Index()
    {
        return View();
    }
}