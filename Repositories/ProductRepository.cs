using Entities.Models;
using Repositories.Contracts;

namespace Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext context) : base(context)
    {

    }

    public void CreateProduct(Product product)
    {
        Create(product);
    }

    public IQueryable<Product> GetAllProducts(bool trackChanges)
    {
        return FindAll(trackChanges);
    }

    public Product? GetOneProduct(int id, bool trackChanges)
    {
        return FindByCondition(x => x.Id.Equals(id), trackChanges);
    }
}