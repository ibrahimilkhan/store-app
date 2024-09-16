using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.Repos;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly RepositoryContext _context;

    protected RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return trackChanges ?
        _context.Set<T>() :
        _context.Set<T>().AsNoTracking();
    }

    public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return trackChanges ?
        _context.Set<T>().Where(expression).SingleOrDefault() :
        _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}