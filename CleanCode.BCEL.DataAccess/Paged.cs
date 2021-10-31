using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAndEntity
{
    public class Paged<T>
    {
        /// <summary>
        /// paging operation is success or not.
        /// </summary>
        public bool IsSuccess { get; protected set; }

        /// <summary>
        /// Error Message if IsSuccess is false.
        /// </summary>
        public string ErrorMessage { get; protected set; }

        /// <summary>
        /// paged data if IsSuccess is true.
        /// </summary>
        public IEnumerable<T> Data { get; protected set; }

        /// <summary>
        /// Total data count.
        /// </summary>
        public int Count { get; protected set; }

        /// <summary>
        /// page count
        /// </summary>
        public int PageCount { get; protected set; }

        /// <summary>
        /// Page Size
        /// </summary>
        public int PageSize { get; protected set; }

        /// <summary>
        /// Page Index
        /// </summary>
        public int PageIndex { get; protected set; }

        /// <summary>
        /// Has Previous Page
        /// </summary>
        public bool HasPreviousPage { get; protected set; }

        /// <summary>
        /// Has Next Page
        /// </summary>
        public bool HasNextPage { get; protected set; }

        /// <summary>
        /// Is FirstPage
        /// </summary>
        public bool IsFirstPage { get; protected set; }
        /// <summary>
        /// Is LastPage
        /// </summary>
        public bool IsLastPage { get; protected set; }

        /// <summary>
        /// constrauct a paged data set
        /// </summary>
        /// <param name="data">paged data</param>
        /// <param name="totalCount">total item count</param>
        /// <param name="pageIndex">page index</param>
        /// <param name="pageSize">page size</param>
        public Paged(IEnumerable<T> data, int totalCount, int pageIndex = 1, int pageSize = 10)
        {
            Data = data;
            Count = totalCount;

            PageIndex = pageIndex;
            PageSize = pageSize;

            PageCount = Count > 0
                            ? (int)Math.Ceiling(totalCount / (double)PageSize)
                            : 0;

            var pageNumberIsGood = PageCount > 0 && pageIndex <= PageCount;

            HasPreviousPage = pageNumberIsGood && pageIndex > 1;
            HasNextPage = pageNumberIsGood && pageIndex < PageCount;
            IsFirstPage = pageNumberIsGood && pageIndex == 1;
            IsLastPage = pageNumberIsGood && pageIndex == PageCount;
            IsSuccess = true;
        }

        public Paged(bool success, string message, IEnumerable<T> data = null, int pageNumber = 1, int pageSize = 10)
        {
            IsSuccess = success;
            ErrorMessage = message;
            Data = data;
            PageIndex = pageNumber;
            PageSize = pageSize;
        }
    }
}
