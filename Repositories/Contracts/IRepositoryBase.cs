using System;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IRepositoryBase<T>
{
    void Create(T entity);
    IQueryable<T> FindAll(bool trackChanges);
    T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
}