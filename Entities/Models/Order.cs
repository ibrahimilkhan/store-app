using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Order
{
    public int Id { get; set; }

    public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

    [Required(ErrorMessage = "Name is required.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "First line is required.")]
    public required string Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }
    public string? City { get; set; }
    public bool IsGift { get; set; }
    public bool IsShipped { get; set; }
    public DateTime OrderTime { get; set; } = DateTime.Now;

}