using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAndEntity
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _ctx;

        public GenericRepository(DbContext dbContext) : base()
        {
            _ctx = dbContext;
        }

        public virtual void Add(T entity)
        {
            _ctx.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _ctx.Remove(entity);
        }

        public virtual ValueTask<T> FindByKey(params object[] key)
        {
            return _ctx.Set<T>().FindAsync(key);
        }

        public virtual Task<int> SaveAsync()
        {
            return _ctx.SaveChangesAsync();
        }

        public virtual IQueryable<T> Where(bool tracking = false)
        {
            return tracking ? _ctx.Set<T>().AsTracking() : _ctx.Set<T>().AsNoTracking();
        }
    }
}
