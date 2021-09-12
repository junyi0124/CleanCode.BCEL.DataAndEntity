namespace CleanCode.BCEL.DataAndEntity
{
    using System.Collections.Generic;
    using System.Linq;
    public class PagedModel<T>
    {
        public int TotalItemCount { get; protected set; }

        public int PageNumber { get; protected set; }

        public int PageSize { get; protected set; }

        public int PageCount { get; protected set; }

        public bool HasPreviousPage { get; protected set; }

        public bool HasNextPage { get; protected set; }

        public bool IsFirstPage { get; protected set; }

        public bool IsLastPage { get; protected set; }

        public IEnumerable<T> Subset { get; protected set; }

        public int Count => Subset.Count();

        public PagedModel(IPagedData<T> data)
        {
            Subset = data.Subset;
            TotalItemCount = data.TotalItemCount;
            PageNumber = data.PageNumber;
            PageSize = data.PageSize;
            PageCount = data.PageCount;
            HasPreviousPage = data.HasPreviousPage;
            HasNextPage = data.HasNextPage;
            IsFirstPage = data.IsFirstPage;
            IsLastPage = data.IsLastPage;
        }
    }
}
