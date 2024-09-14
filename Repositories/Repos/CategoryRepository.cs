using System;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories.Repos;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(RepositoryContext context) : base(context)
    {
    }
}