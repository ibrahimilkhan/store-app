using System;
using Entities.Models;

namespace Repositories.Extensions;

public static class ProductRepositoryExtension
{
    public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int? categoryId)
    {
        if (categoryId is null)
            return products;
        else
            return products.Where(prd => prd.CategoryId.Equals(categoryId));
    }

    public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return products;
        else
            return products.Where(x => x.Name != null && x.Name.ToLower().Contains(searchTerm.ToLower()));

    }
}