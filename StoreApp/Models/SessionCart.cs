using System;
using Entities.Models;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Models;

public class SessionCart : Cart
{
    public ISession? Session { get; set; }

    public static Cart GetCart(IServiceProvider serviceProdiver)
    {
        ISession? session = serviceProdiver.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
        SessionCart? sessionCart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();

        sessionCart.Session = session;
        return sessionCart;
    }


    public override void AddProduct(Product product, int quantity)
    {

        base.AddProduct(product, quantity);
    }

    public override void RemoveProductLine(Product product, int quantity)
    {
        base.RemoveProductLine(product, quantity);
    }

    public override decimal CalculateTotalAmount()
    {
        return base.CalculateTotalAmount();
    }

}
