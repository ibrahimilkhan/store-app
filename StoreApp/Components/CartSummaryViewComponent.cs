using System;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly Cart _cart;

    public CartSummaryViewComponent(Cart cart)
    {
        _cart = cart;
    }

    public string Invoke()
    {
        var count = 0;

        foreach (var item in _cart.CartLines)
            count += 1;

        return count.ToString();
    }
}