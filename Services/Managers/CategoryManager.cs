using System;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Managers;

public class CategoryManager : ICategoryService
{
    private readonly IRepositoryManager _repoManager;

    public CategoryManager(IRepositoryManager repoManager)
    {
        _repoManager = repoManager;
    }
    public IEnumerable<Category> GetAllCategories(bool trackChanges)
    {
        return _repoManager.CategoryRepo.FindAll(trackChanges);
    }

    public Category? GetCategory(int id, bool trackChanges)
    {
        return _repoManager.CategoryRepo.FindByCondition(x=>x.Id == id, trackChanges);
    }
}