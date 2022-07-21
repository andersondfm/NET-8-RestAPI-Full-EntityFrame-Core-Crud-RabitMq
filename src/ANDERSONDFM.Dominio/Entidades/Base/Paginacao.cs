using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANDERSONDFM.Dominio.Entidades
{
    public class Paginacao
    {
        #region Properties
        /// <summary>
        /// IQueryable data result to return.
        /// </summary>
        /// <summary>
        /// Zero-based index of current page.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Number of items contained in each page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total items count
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Total pages count
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// TRUE if the current page has a previous page,
        /// FALSE otherwise.
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        /// <summary>
        /// TRUE if the current page has a next page, FALSE otherwise.
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return ((PageIndex + 1) < TotalPages);
            }
        }

        /// <summary>
        /// Sorting Column name (or null if none set)
        /// </summary>
        public string? SortColumn { get; set; }

        /// <summary>
        /// Sorting Order ("ASC", "DESC" or null if none set)
        /// </summary>
        public string? SortOrder { get; set; }

        /// <summary>
        /// Filter Column name (or null if none set)
        /// </summary>
        public string? FilterColumn { get; set; }

        /// <summary>
        /// Filter Query string 
        /// (to be used within the given FilterColumn)
        /// </summary>
        public string? FilterQuery { get; set; }
        #endregion
    }

}
