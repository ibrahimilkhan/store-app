using System;

namespace Repositories.Contracts;

public interface IRepositoryManager
{
    IProductRepository ProductRepo { get; }
    ICategoryRepository CategoryRepo { get; }
    IOrderRepository OrderRepo { get; }
    void Save();
}