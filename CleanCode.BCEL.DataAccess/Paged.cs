using CleanCode.BCEL.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAccess
{
    public class Paged<T> : List<T>, IPaged<T>
    {
        private bool pageIndexIsOk;

        public Paged(List<T> items, int totalCount, int pageIndex = 1, int pageSize = 10)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            pageIndexIsOk = PageIndex > 0 && pageIndex <= TotalPages;
            this.AddRange(items);

            /*
             *             
             *             Count = totalCount;

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
             * 
             */
        }


        public Paged(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Error Message if IsSuccess is false.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Total data count.
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// current page index
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// total page count number
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Is FirstPage
        /// </summary>
        public bool IsFirstPage
        {
            get { return pageIndexIsOk && PageIndex == 1; }
        }
        /// <summary>
        /// Is LastPage
        /// </summary>
        public bool IsLastPage
        {
            get { return pageIndexIsOk && PageIndex == TotalPages; }
        }

        /// <summary>
        /// result Has Previous Page
        /// </summary>
        public bool HasPreviousPage
        {
            get { return pageIndexIsOk && PageIndex > 1; }
        }

        /// <summary>
        /// result Has Next Page
        /// </summary>
        public bool HasNextPage
        {
            get { return pageIndexIsOk && PageIndex < TotalPages; }
        }

    }

}
