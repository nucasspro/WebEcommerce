using System;
using System.Collections.Generic;

namespace WebEcommerce.Utility.DTOs
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public PagedResult()
        {
            Results = new List<T>();
        }

        public IList<T> Results { get; set; }
    }

    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }

        public int PageCount
        {
            get
            {
                var pageCount = (double)RowCount / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
            set { PageCount = value; }
        }

        public int PageSize { get; set; }

        public int RowCount { get; set; }

        public int FirstRowOnPage
        {
            get
            {
                return (CurrentPage - 1) * PageSize + 1;
            }
        }

        public int LastRowOnPage
        {
            get
            {
                return Math.Min(CurrentPage * PageSize, RowCount);
            }
        }
    }
}