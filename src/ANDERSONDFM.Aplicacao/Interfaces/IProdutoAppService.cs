using ANDERSONDFM.Compartilhado.ViewModel;
using ANDERSONDFM.Dominio.Entidades;

namespace ANDERSONDFM.Aplicacao.Interfaces
{
    public interface IProdutoAppService
    {
        Task<RetornoPadrao>GetAllProdutcsAsync(int pageIndex, int pageSize, string? sortColumn = null, string? sortOrder = null, string? filterColumn = null, string? filterQuery = null);
        Task<RetornoPadrao> FindIdProdutcAsync(int id);
    }
}
