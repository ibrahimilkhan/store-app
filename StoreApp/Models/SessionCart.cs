using System;
using System.Text.Json.Serialization;
using Entities.Models;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Models;

public class SessionCart : Cart
{
    [JsonIgnore]
    public ISession? Session { get; set; }

    public static Cart GetCart(IServiceProvider serviceProdiver)
    {
        ISession? session = serviceProdiver.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
        SessionCart? sessionCart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();

        sessionCart.Session = session;
        return sessionCart;
    }


    public override void AddItem(Product product, int quantity)
    {
        base.AddItem(product, quantity);
        Session?.SetJson<SessionCart>("cart", this);
    }


    public override void RemoveLine(Product product)
    {
        base.RemoveLine(product);
        Session?.SetJson<SessionCart>("cart", this);

    }

    public override void Clear()
    {
        base.Clear();
        Session?.Remove("cart");
    }
}