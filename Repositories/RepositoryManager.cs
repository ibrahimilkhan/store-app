using System;
using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;

    public RepositoryManager(RepositoryContext context, IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _context = context;
        _productRepo = productRepository;
        _categoryRepo = categoryRepository;
    }

    private readonly IProductRepository _productRepo;
    public IProductRepository ProductRepo => _productRepo;

    private readonly ICategoryRepository _categoryRepo;
    public ICategoryRepository CategoryRepo => _categoryRepo;



    public void Save()
    {
        _context.SaveChanges();
    }
}
