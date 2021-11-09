using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.BCEL.BaseEntity
{
    public interface IPaged<T> : IEnumerable<T>
    {
        string ErrorMessage { get; }

        /// <summary>
        /// Total data count.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// current page index
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// total page count number
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Is FirstPage
        /// </summary>
        bool IsFirstPage { get; }
        /// <summary>
        /// Is LastPage
        /// </summary>
        bool IsLastPage { get; }

        /// <summary>
        /// result Has Previous Page
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// result Has Next Page
        /// </summary>
        bool HasNextPage { get; }
    }

}
