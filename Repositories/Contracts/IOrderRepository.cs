using System;
using Entities.Models;

namespace Repositories.Contracts;

public interface IOrderRepository : IRepositoryBase<Order>
{
    IQueryable<Order> Orders { get; }

    Order? GetOneOrder(int id);

    void Complete(int id);
    void SaveOrder(Order order);

    int NumberOfInProcess { get; }
}
