using System;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts(bool trackChanges);
    IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
    IEnumerable<Product> GetShowcaseProduct(bool trackChanges);
    IEnumerable<ProductDtoForView> GetAllProductDtosForView(bool trackChanges);
    Product? GetProduct(int id, bool trackChanges);
    ProductDtoForUpdate? GetProductDtoForUpdate(int id, bool trackChanges);
    void CreateProduct(ProductDtoForInsertion product);
    void UpdateOneProduct(ProductDtoForUpdate product);
    void DeleteProduct(int id);
}