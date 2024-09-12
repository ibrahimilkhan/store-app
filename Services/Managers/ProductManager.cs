using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Managers;

public class ProductManager : IProductService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public ProductManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public void CreateProduct(ProductDtoForInsertion productDto)
    {
        var product = _mapper.Map<Product>(productDto);

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