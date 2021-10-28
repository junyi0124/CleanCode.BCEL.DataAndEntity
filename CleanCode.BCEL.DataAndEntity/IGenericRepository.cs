using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAndEntity
{
    public interface IGenericRepository<T, TId> where T : EntityBase<TId>, IAggregateRoot where TId : IComparable
    {
        IQueryable<T> Where(bool tracking = false);
        ValueTask<T> FindAsync(TId id);
        ValueTask<T> FindAsync(params object[] keyValues);

        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);



        Task<int> SaveAsync();
        EntityEntry<T> Add(T entity);
        EntityEntry<T> Update(T entity);
        EntityEntry<T> Delete(T entity);

        Task<Paged<T>> GetPaged(Expression<Func<T, bool>> predicate, int pageIndex = 1, int pageSize = 10);
        Task<int> CountAsync();
        //Task<int> CountAsync(Predicate<T> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    }
}
