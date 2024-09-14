using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Repos;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext context) : base(context)
    {

    }

    public void CreateProduct(Product product)
    {
        Create(product);
    }

    public void DeleteProduct(Product product)
    {
        Delete(product);
    }

    public IQueryable<Product> GetAllProducts(bool trackChanges)
    {
        return FindAll(trackChanges);
    }

    public Product? GetOneProduct(int id, bool trackChanges)
    {
        return FindByCondition(x => x.Id.Equals(id), trackChanges);
    }

    public void UpdateOneProduct(Product product)
    {
        Update(product);
    }
}