using ANDERSONDFM.Compartilhado.ViewModel;

namespace ANDERSONDFM.Aplicacao.Interfaces
{
    public interface IProdutoAppService
    {
        Task<RetornoPadrao>ObterTodosProdutos(int pageIndex, int pageSize, string? sortColumn = null, string? sortOrder = null, string? filterColumn = null, string? filterQuery = null);
    }
}
