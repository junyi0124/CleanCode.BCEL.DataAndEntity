using CleanCode.BCEL.BaseEntity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAccess
{
    public interface IGenericRepository<T, TId> where T : EntityBase<TId>, IAggregateRoot where TId : IEquatable<TId>
    {

        #region query

        IQueryable<T> Where(bool tracking = false);

        ValueTask<T> FindAsync(TId id);

        ValueTask<T> FindAsync(params object[] keyValues);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> ListAsync();

        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);

        Task<Paged<T>> ToPagedListAsync(Expression<Func<T, bool>> predicate, int pageIndex = 1, int pageSize = 10);

        Task<int> CountAsync();

        //Task<int> CountAsync(Predicate<T> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync();

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        #endregion



        #region commands

        Task<int> SaveChangesAsync();

        EntityEntry<T> Add(T entity);

        EntityEntry<T> Update(T entity);

        EntityEntry<T> Remove(T entity);

        #endregion





    }
}
