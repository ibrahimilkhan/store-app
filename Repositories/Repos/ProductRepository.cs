using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
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

    public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
    {
        return p.CategoryId is null
            ? _context
                .Products
                .Include(prd => prd.Category)
            : _context
                .Products
                .Include(prd => prd.Category)
                .Where(prd => prd.CategoryId.Equals(p.CategoryId));
    }

    public Product? GetOneProduct(int id, bool trackChanges)
    {
        return FindByCondition(x => x.Id.Equals(id), trackChanges);
    }

    public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
    {
        return FindAll(trackChanges).Where(x => x.ShowCase.Equals(true));
    }

    public void UpdateOneProduct(Product product)
    {
        Update(product);
    }
}