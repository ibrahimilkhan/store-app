namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> CartLines { get; set; }
        public Cart()
        {
            CartLines = new List<CartLine>();
        }

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = CartLines.Where(l => l.Product.Id.Equals(product.Id))
            .FirstOrDefault();

            if (line is null)
            {
                CartLines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }

        }

        public virtual void RemoveLine(Product product) =>
            CartLines.RemoveAll(l => l.Product.Id.Equals(product.Id));
        
        public decimal ComputeTotalValue() => 
            CartLines.Sum(e => e.Product.Price * e.Quantity);
        
        public virtual void Clear() => CartLines.Clear();
    }
}