using CleanCode.BCEL.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAccess
{
    public class PagedListHelper<T>
    {
        public static async Task<Paged<T>> ToPagedListAsync(IQueryable<T> query, int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var count = await query.CountAsync();
                var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                return new Paged<T>(items, count, pageIndex, pageSize);
            }
            catch (Exception e)
            {
                return new Paged<T>("error" + e.Message);
            }
        }


    }
}
