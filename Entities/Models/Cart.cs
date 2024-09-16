namespace Entities.Models;

public class Cart
{
    public List<CartLine> CartLines { get; set; }

    public Cart()
    {
        CartLines = [];
    } 

    public void AddProduct(Product product, int quantity)
    {
        var line = CartLines.FirstOrDefault(x => x.Product.Id == product.Id);

        if (line != null)
        {
            line.Quantity += quantity;
        }
        else
        {
            CartLines.Add(new CartLine
            {
                Product = product,
                Quantity = quantity
            });
        }
    }

    public void RemoveProductLine(Product product, int quantity)
    {
        var line = CartLines.FirstOrDefault(x => x.Product.Id == product.Id);

        if (line != null)
        {
            CartLines.RemoveAll(x => x.Product.Id == product.Id);
        }
    }

    public decimal CalculateTotalAmount()
    {
        decimal totalAmount = 0;

        foreach (CartLine line in CartLines)
        {
            totalAmount += line.Quantity * line.Product.Price;
        }

        return totalAmount;
    }

    public void Clear()
    {
        CartLines.Clear();
    }
}