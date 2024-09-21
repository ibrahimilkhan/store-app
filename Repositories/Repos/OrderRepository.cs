using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.Repos;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(RepositoryContext context) : base(context)
    {

    }

    public IQueryable<Order> Orders => _context.Orders.Include(o => o.Lines)
                                                       .ThenInclude(cl => cl.Product)
                                                       .OrderBy(o => o.IsShipped)
                                                       .ThenByDescending(o => o.Id);

    public int NumberOfInProcess => _context.Orders.Count(o => o.IsShipped.Equals(false));

    public void Complete(int id)
    {
        var order = FindByCondition(x => x.Id == id, true);

        if (order is null)
            throw new Exception("Order couldn't find!");

        order.IsShipped = true;

        _context.SaveChanges();

    }

    public Order? GetOneOrder(int id)
    {
        return FindByCondition(x => x.Id == id, false);
    }

    public void SaveOrder(Order order)
    {
        _context.AttachRange(order.Lines.Select(x => x.Product));

        if (order.Id == 0)
            _context.Orders.Add(order);

        _context.SaveChanges();
    }
}