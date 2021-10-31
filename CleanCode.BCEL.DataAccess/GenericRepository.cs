using CleanCode.BCEL.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAndEntity
{
    public abstract class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : EntityBase<TId>, IAggregateRoot where TId : IEquatable<TId>
    {
        private readonly DbContext _ctx;

        public GenericRepository(DbContext dbContext) : base()
        {
            _ctx = dbContext;
        }

        public EntityEntry<T> Add(T entity)
        {
            return _ctx.Add(entity);
        }
        public EntityEntry<T> Delete(T entity)
        {
            return _ctx.Remove(entity);
        }
        public EntityEntry<T> Update(T entity)
        {
            return _ctx.Update(entity);
        }
        public virtual Task<int> SaveAsync()
        {
            return _ctx.SaveChangesAsync();
        }

        public ValueTask<T> FindAsync(TId id)
        {
            return _ctx.FindAsync<T>(id);
        }

        public ValueTask<T> FindAsync(params object[] keyValues)
        {
            return _ctx.FindAsync<T>(keyValues);
        }




        public async Task<Paged<T>> ToPaged(Expression<Func<T, bool>> predicate, int pageIndex = 1, int pageSize = 10)
        {
            //var result = new PagedModel<T>();
            //result.PageSize = pageSize;

            //if (CheckPageParameters(pageIndex, pageSize))
            //{
            //    result.IsSuccess = false;
            //    result.ErrorMessage = "pageIndex or pageSize invalid";
            //    return result;
            //}

            //var count = await CountAsync(predicate);
            //if (count < pageSize * pageIndex)
            //{
            //    result.PageIndex = count / pageSize;
            //}
            //else
            //{
            //    result.PageIndex = pageIndex;
            //}
            //result.Data = await Where(false).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

            //return result;


            if (CheckPageParameters(pageIndex, pageSize))
            {
                return new Paged<T>(false, "pageIndex or pageSize invalid");
            }

            var query = predicate == null
                ? Where(false)
                : Where(false).Where(predicate);

            int count = await query.CountAsync();

            if (count == 0)
            {
                return new Paged<T>(false, "empty result");
            }

            var data = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize)
                            .ToListAsync(CancellationToken.None).ConfigureAwait(false);

            return new Paged<T>(data, count, pageIndex, pageSize);
        }

        private bool CheckPageParameters(int pageIndex, int pageSize)
        {
            if (pageIndex < 1 || pageSize < 1) return true;
            return false;
        }


        public Task<List<T>> ListAsync()
        {
            return Where().ToListAsync();
        }

        public Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return Where().Where(predicate).ToListAsync();
        }

        public Task<int> CountAsync()
        {
            return Where().CountAsync();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().CountAsync(predicate);
        }


        public virtual IQueryable<T> Where(bool tracking = false)
        {
            return tracking
                ? _ctx.Set<T>().AsTracking()
                : _ctx.Set<T>().AsNoTracking();
        }
    }
}
