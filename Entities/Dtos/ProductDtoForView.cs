namespace Entities.Dtos;

public record ProductDtoForView : ProductDto
{
    public string? CategoryName { get; init; }
}