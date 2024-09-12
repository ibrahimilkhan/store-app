using System;
using Services.Contracts;

namespace Services.Managers;

public class ServiceManager : IServiceManager
{
    private readonly ICategoryService _categoryService;
    public ICategoryService CategoryService => _categoryService;

    private readonly IProductService _productService;
    public IProductService ProductService => _productService;

    public ServiceManager(ICategoryService categoryService, IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
    }
}