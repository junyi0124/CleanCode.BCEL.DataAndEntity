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
        /// <summary>
        /// get paged data function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="superset"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<PagedMetadata<T>> ToPagedDataAsync<T>(this IQueryable<T> superset, 
            int? pageNumber, int pageSize,
            CancellationToken cancellationToken)
        {
            // check page number validation
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(
                    $"pageNumber = {pageNumber}. PageNumber cannot be below 1.");
            }
            // check page size validation
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(
                    $"pageSize = {pageSize}. PageSize cannot be less than 1.");
            }
            // ensure page number
            int pn = pageNumber ?? 1;
            // paged data collection
            var subset = new List<T>();
            var totalCount = 0;

            if (superset != null)
            {
                // trigger first query
                totalCount = superset.Count();
                if (totalCount > 0)
                {
                    subset.AddRange(
                        //(pn == 1) ? 
                        //    await superset.Skip(0).Take(pageSize).ToListAsync(cancellationToken)
                        //        .ConfigureAwait(false)
                        //    : await superset.Skip(((pn - 1) * pageSize)).Take(pageSize)
                        //        .ToListAsync(cancellationToken).ConfigureAwait(false)
                        await superset.Skip((pn - 1) * pageSize).Take(pageSize)
                            .ToListAsync(cancellationToken).ConfigureAwait(false)
                    );
                }
            }

            return new PagedMetadata<T>(subset, pn, pageSize, totalCount);
        }

        /// <summary>
        /// shorter version of ToPagedDataAsync<typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="superset"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Task<PagedMetadata<T>> ToPagedDataAsync<T>(this IQueryable<T> superset, int pageNumber = 1, int pageSize = 10)
        {
            return superset.ToPagedDataAsync(pageNumber, pageSize, CancellationToken.None);
        }
    }
}
