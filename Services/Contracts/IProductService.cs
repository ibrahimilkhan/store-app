using System;
using Entities.Models;

namespace Services.Contracts;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts(bool trackChanges);
    Product? GetProduct(int id, bool trackChanges);
    void CreateProduct(Product product);
    void UpdateOneProduct(Product product);
}