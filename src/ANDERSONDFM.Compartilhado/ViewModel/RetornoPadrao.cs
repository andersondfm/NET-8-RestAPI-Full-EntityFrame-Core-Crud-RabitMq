
using System.ComponentModel;
using System.Security.AccessControl;

namespace ANDERSONDFM.Compartilhado.ViewModel
{
    public class RetornoPadrao
    {
        public int Id { get; set; }
        public object data { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public List<string> Mensagens { get; set; }
        public bool excluido { get; set; }
    }
}
