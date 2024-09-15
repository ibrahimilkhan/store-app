using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public string? Summary { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }

}