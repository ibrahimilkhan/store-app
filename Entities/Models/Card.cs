using System;
using System.Security.Cryptography.X509Certificates;

namespace Entities.Models;

public class Card
{
    public List<CardLine> CardLines { get; set; }

    public Card()
    {
        CardLines = [];
    }

    public void AddProduct(Product product, int quantity)
    {
        var line = CardLines.FirstOrDefault(x => x.Product.Id == product.Id);

        if (line != null)
        {
            line.Quantity += quantity;
        }
        else
        {
            CardLines.Add(new CardLine
            {
                Product = product,
                Quantity = quantity
            });
        }
    }

    public void RemoveProductLine(Product product, int quantity)
    {
        var line = CardLines.FirstOrDefault(x => x.Product.Id == product.Id);

        if (line != null)
        {
            CardLines.RemoveAll(x => x.Product.Id == product.Id);
        }
    }

    public decimal CalculateTotalAmount()
    {
        decimal totalAmount = 0;

        foreach (CardLine line in CardLines)
        {
            totalAmount += line.Quantity * line.Product.Price;
        }

        return totalAmount;
    }

    public void Clear()
    {
        CardLines.Clear();
    }
}