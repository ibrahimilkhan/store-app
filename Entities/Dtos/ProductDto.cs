using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record ProductDto
{
    public int Id { get; init; }

    [Required(ErrorMessage = "Name is required.")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Price is required.")]
    public decimal Price { get; init; }

    public int? CategoryId { get; init; }

}