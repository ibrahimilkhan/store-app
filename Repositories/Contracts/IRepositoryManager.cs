using System;

namespace Repositories.Contracts;

public interface IRepositoryManager
{
    IProductRepository ProductRepo { get; }
    ICategoryRepository CategoryRepo { get; }
    void Save();
}