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

    public IEnumerable<ProductDtoForView> GetAllProductDtosForView(bool trackChanges)
    {
        var products = _repositoryManager.ProductRepo.GetAllProducts(false); // Retrieve products
        return _mapper.Map<IEnumerable<ProductDtoForView>>(products);
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

    public ProductDtoForUpdate? GetProductDtoForUpdate(int id, bool trackChanges)
    {
        var product = _repositoryManager.ProductRepo.GetOneProduct(id, trackChanges);
        var productDto = _mapper.Map<ProductDtoForUpdate>(product);
        return productDto;
    }

    public void UpdateOneProduct(ProductDtoForUpdate productDto)
    {
        if (productDto.ImageUrl == null)
        {
            var formerProd = GetProduct(productDto.Id, false);
            productDto.ImageUrl = formerProd?.ImageUrl;
        }

        var product = _mapper.Map<Product>(productDto);
        _repositoryManager.ProductRepo.UpdateOneProduct(product);
        _repositoryManager.Save();
    }
}