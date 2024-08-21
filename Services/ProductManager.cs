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

    public IEnumerable<Product> GetAllProducts(bool trackChanges)
    {
        return _repositoryManager.ProductRepo.GetAllProducts(trackChanges);
    }

    public Product? GetProduct(int id, bool trackChanges)
    {
        var product = _repositoryManager.ProductRepo.GetOneProduct(id, trackChanges) ?? throw new Exception("Product not found!");
        return product;
    }
}