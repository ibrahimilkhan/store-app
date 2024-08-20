using System;
using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;

    public RepositoryManager(RepositoryContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    private readonly IProductRepository _productRepository;
    public IProductRepository Product => _productRepository;


    public void Save()
    {
        _context.SaveChanges();
    }
}
