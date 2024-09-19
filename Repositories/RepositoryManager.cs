using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;

    public RepositoryManager(RepositoryContext context,
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IOrderRepository orderRepository)
    {
        _context = context;
        _productRepo = productRepository;
        _categoryRepo = categoryRepository;
        _orderRepo = orderRepository;
    }

    private readonly IProductRepository _productRepo;
    public IProductRepository ProductRepo => _productRepo;

    private readonly ICategoryRepository _categoryRepo;
    public ICategoryRepository CategoryRepo => _categoryRepo;


    private readonly IOrderRepository _orderRepo;
    public IOrderRepository OrderRepo => _orderRepo;


    public void Save()
    {
        _context.SaveChanges();
    }
}