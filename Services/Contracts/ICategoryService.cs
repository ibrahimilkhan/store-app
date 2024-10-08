using System;
using Entities.Models;

namespace Services.Contracts;

public interface ICategoryService
{
    IEnumerable<Category> GetAllCategories(bool trackChanges);

    Category? GetCategory(int id, bool trackChanges);
}