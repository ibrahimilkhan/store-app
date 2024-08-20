using System;
using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;

    public RepositoryManager(RepositoryContext context, IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _context = context;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    private readonly IProductRepository _productRepository;
    public IProductRepository ProductRepository => _productRepository;

    private readonly ICategoryRepository _categoryRepository;
    public ICategoryRepository CategoryRepository => _categoryRepository;


    public void Save()
    {
        _context.SaveChanges();
    }
}
