using System;
using Services.Contracts;

namespace Services.Managers;

public class ServiceManager : IServiceManager
{
    private readonly ICategoryService _categoryService;
    public ICategoryService CategoryService => _categoryService;

    private readonly IProductService _productService;
    public IProductService ProductService => _productService;

    private readonly IOrderService _orderService;
    public IOrderService OrderService => _orderService;

    public ServiceManager(ICategoryService categoryService, IProductService productService, IOrderService orderService)
    {
        _categoryService = categoryService;
        _productService = productService;
        _orderService = orderService;
    }
}