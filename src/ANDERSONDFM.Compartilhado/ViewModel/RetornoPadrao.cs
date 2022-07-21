
namespace ANDERSONDFM.Compartilhado.ViewModel
{
    public class RetornoPadrao
    {
        public object data { get; set; }
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

        public bool HasPreviousPage { get; set; }
        
        /// <summary>
        /// TRUE if the current page has a next page, FALSE otherwise.
        /// </summary>
        public bool HasNextPage { get; set; }

        public List<string> Mensagens { get; set; }
    }
}
