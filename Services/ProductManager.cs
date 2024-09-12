using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class ProductManager : IProductService
{
    private readonly IRepositoryManager _repositoryManager;

    public ProductManager(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public void CreateProduct(ProductDtoForInsertion productDto)
    {
        var product = new Product()
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            CategoryId = productDto.CategoryId,
        };
        
        _repositoryManager.ProductRepo.CreateProduct(product);
        _repositoryManager.Save();
    }

    public void DeleteProduct(int id)
    {
        var product = GetProduct(id, false);

        if (product != null)
        {
            _repositoryManager.ProductRepo.DeleteProduct(product);
            _repositoryManager.Save();
        }
    }

    public IEnumerable<Product> GetAllProducts(bool trackChanges)
    {
        return _repositoryManager.ProductRepo.GetAllProducts(trackChanges);
    }

    public Product? GetProduct(int id, bool trackChanges)
    {
        var product = _repositoryManager.ProductRepo.GetOneProduct(id, trackChanges) ?? throw new Exception("Product not found!");
        return product;
    }

    public void UpdateOneProduct(Product product)
    {
        var formerProduct = GetProduct(product.Id, true);

        if (formerProduct != null)
        {
            formerProduct.Price = product.Price;
            formerProduct.Name = product.Name;

            _repositoryManager.Save();
        }
    }
}