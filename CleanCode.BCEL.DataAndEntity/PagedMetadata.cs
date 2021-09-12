using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CleanCode.BCEL.DataAndEntity
{
    public class PagedMetadata<T> : IPagedData<T>
    {

        public int TotalItemCount { get; protected set; }

        public int PageNumber { get; protected set; }

        public int PageSize { get; protected set; }

        public int PageCount { get; protected set; }

        public bool HasPreviousPage { get; protected set; }

        public bool HasNextPage { get; protected set; }

        public bool IsFirstPage { get; protected set; }

        public bool IsLastPage { get; protected set; }

        public int Count => Subset.Count();

        public List<T> Subset { get; protected set; }

        public T this[int index] => Subset[index];

        private PagedMetadata() { }
        public PagedMetadata(List<T> subset, int totalCount, int pageSize, int pageNumber)
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

        public IEnumerator<T> GetEnumerator()
        {
            return Subset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
