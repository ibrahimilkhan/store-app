using System;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers;

public class OrderController : Controller
{
    private readonly IServiceManager _manager;
    private readonly Cart _cart;

    public OrderController(IServiceManager manager, Cart cart)
    {
        _manager = manager;
        _cart = cart;
    }

    public ViewResult Checkout() => View(new Order());


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Checkout([FromForm] Order order)
    {
        if (order.Lines.Count() == 0)
        {
            ModelState.AddModelError("", "Your cart is empty!");
        }

        if (ModelState.IsValid)
        {
            order.Lines = _cart.CartLines.ToArray();
            _manager.OrderService.SaveOrder(order);
            _cart.Clear();

            return RedirectToPage("/Complete", new { OrderId = order.Id });
        }
        else
        {
            return View();
        }
    }
}