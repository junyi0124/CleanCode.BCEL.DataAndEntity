using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAndEntity
{
    public class PagedMetadata<T> : IPagedData<T>
    {
        public IEnumerable<T> Subset { get; protected set; }

        public int TotalItemCount { get; protected set; }

        public int PageNumber { get; protected set; }

        public int PageSize { get; protected set; }

        public int PageCount { get; protected set; }

        public bool HasPreviousPage { get; protected set; }

        public bool HasNextPage { get; protected set; }

        public bool IsFirstPage { get; protected set; }

        public bool IsLastPage { get; protected set; }


        private PagedMetadata() { }
        public PagedMetadata(IEnumerable<T> subset, int totalCount, int pageSize, int pageNumber)
        {
            this.Subset = subset;
            TotalItemCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
            PageCount = TotalItemCount > 0
                            ? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
                            : 0;

            var pageNumberIsGood = PageCount > 0 && PageNumber <= PageCount;

            HasPreviousPage = pageNumberIsGood && PageNumber > 1;
            HasNextPage = pageNumberIsGood && PageNumber < PageCount;
            IsFirstPage = pageNumberIsGood && PageNumber == 1;
            IsLastPage = pageNumberIsGood && PageNumber == PageCount;
        }

    }

    public interface IPagedData<T>
    {
        /// <summary>
        /// Paged data collection.
        /// </summary>
        IEnumerable<T> Subset { get; }

        /// <summary>
        /// Total number of objects contained within the superset.
        /// </summary>
        /// <value>
        /// Total number of objects contained within the superset.
        /// </value>
        int TotalItemCount { get; }
        /// <summary>
        /// One-based index of this subset within the superset, zero if the superset is empty.
        /// </summary>
        /// <value>
        /// One-based index of this subset within the superset, zero if the superset is empty.
        /// </value>
        int PageNumber { get; }

        /// <summary>
        /// Maximum size any individual subset.
        /// </summary>
        /// <value>
        /// Maximum size any individual subset.
        /// </value>
        int PageSize { get; }
        /// <summary>
        /// Total number of subsets within the superset.
        /// </summary>
        /// <value>
        /// Total number of subsets within the superset.
        /// </value>
        int PageCount { get; }

        /// <summary>
        /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
        /// is NOT the first subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
        /// is NOT the first subset within the superset.
        /// </value>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
        /// is NOT the last subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
        /// is NOT the last subset within the superset.
        /// </value>
        bool HasNextPage { get; }

        /// <summary>
        /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
        /// is the first subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
        /// is the first subset within the superset.
        /// </value>
        bool IsFirstPage { get; }

        /// <summary>
        /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
        /// is the last subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
        /// is the last subset within the superset.
        /// </value>
        bool IsLastPage { get; }

        ///// <summary>
        ///// One-based index of the first item in the paged subset, zero if the superset is empty or PageNumber
        ///// is greater than PageCount.
        ///// </summary>
        ///// <value>
        ///// One-based index of the first item in the paged subset, zero if the superset is empty or PageNumber
        ///// is greater than PageCount.
        ///// </value>
        //int FirstItemOnPage { get; }

        ///// <summary>
        ///// One-based index of the last item in the paged subset, zero if the superset is empty or PageNumber
        ///// is greater than PageCount.
        ///// </summary>
        ///// <value>
        ///// One-based index of the last item in the paged subset, zero if the superset is empty or PageNumber
        ///// is greater than PageCount.
        ///// </value>
        //int LastItemOnPage { get; }
    }
}
