using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.BCEL.DataAndEntity
{
    public static class PagedDataExtensions
    {
        public static async Task<IPagedData<T>> ToPagedDataAsync<T>(this IQueryable<T> superset, int? pageNumber, int pageSize,
            CancellationToken cancellationToken)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException($"pageNumber = {pageNumber}. PageNumber cannot be below 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException($"pageSize = {pageSize}. PageSize cannot be less than 1.");
            }
            int pn = pageNumber ?? 1;

            var subset = new List<T>();
            var totalCount = 0;

            if (superset != null)
            {
                totalCount = superset.Count();
                if (totalCount > 0)
                {
                    subset.AddRange(
                        (pageNumber == 1)
                            ? await superset.Skip(0).Take(pageSize).ToListAsync(cancellationToken).ConfigureAwait(false)
                            : await superset.Skip(((pn - 1) * pageSize)).Take(pageSize)
                            .ToListAsync(cancellationToken).ConfigureAwait(false)
                    );
                }
            }

            return new PagedMetadata<T>(subset, pn, pageSize, totalCount);
        }

        public static Task<IPagedData<T>> ToPagedDataAsync<T>(this IQueryable<T> superset, int pageNumber = 1, int pageSize = 10)
        {
            return superset.ToPagedDataAsync(pageNumber, pageSize, CancellationToken.None);
        }
    }
}
