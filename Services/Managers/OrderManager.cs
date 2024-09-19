using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Managers;

public class OrderManager : IOrderService
{
    private readonly IRepositoryManager _manager;


    public OrderManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public IQueryable<Order> Orders => _manager.OrderRepo.Orders;

    public int NumberOfInProcess => _manager.OrderRepo.NumberOfInProcess;

    public void Complete(int id)
    {
        _manager.OrderRepo.Complete(id);
        _manager.Save();
    }

    public Order? GetOneOrder(int id)
    {
        return _manager.OrderRepo.GetOneOrder(id);
    }

    public void SaveOrder(Order order)
    {
        _manager.OrderRepo.SaveOrder(order);
        _manager.Save();
    }
}