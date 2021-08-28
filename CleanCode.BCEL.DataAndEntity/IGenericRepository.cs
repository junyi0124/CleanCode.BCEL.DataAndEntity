using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAndEntity
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> SaveAsync();

        void Add(T entity);

        void Delete(T entity);

        IQueryable<T> Where(bool tracking = false);

        ValueTask<T> FindByKey(params object[] key);
    }
}
