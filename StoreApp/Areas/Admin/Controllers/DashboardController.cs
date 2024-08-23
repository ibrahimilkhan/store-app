using System;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    public ViewResult Index()
    {
        return View();
    }

}
