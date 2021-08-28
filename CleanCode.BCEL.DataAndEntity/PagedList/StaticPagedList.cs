﻿using System;
using System.Collections.Generic;

namespace CleanCode.BCEL.DataAndEntity
{
    public class StaticPagedList<T> : BasePagedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StaticPagedList{T}"/> class that contains the already
        /// divided subset and information about the size of the superset and the subset's position within it.
        /// </summary>
        /// <param name="subset">The single subset this collection should represent.</param>
        /// <param name="metaData">
        /// Supply the ".MetaData" property of an existing IPagedList instance to recreate
        /// it here (such as when creating a new instance of a PagedList after having used Automapper to convert
        /// its contents to a DTO.)
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
        public StaticPagedList(IEnumerable<T> subset, IPagedList metaData)
            : this(subset, metaData.PageNumber, metaData.PageSize, metaData.TotalItemCount)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticPagedList{T}"/> class that contains the already
        /// divided subset and information about the size of the superset and the subset's position within it.
        /// </summary>
        /// <param name="subset">The single subset this collection should represent.</param>
        /// <param name="pageNumber">The one-based index of the subset of objects contained by this instance.</param>
        /// <param name="pageSize">The maximum size of any individual subset.</param>
        /// <param name="totalItemCount">The size of the superset.</param>
        /// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
        public StaticPagedList(IEnumerable<T> subset, int pageNumber, int pageSize, int totalItemCount)
            : base(pageNumber, pageSize, totalItemCount)
        {
            Subset.AddRange(subset);
        }
    }
}