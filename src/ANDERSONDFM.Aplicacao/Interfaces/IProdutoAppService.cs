using ANDERSONDFM.Compartilhado.ViewModel;
using ANDERSONDFM.Dominio.Entidades;

namespace ANDERSONDFM.Aplicacao.Interfaces
{
    public interface IProdutoAppService
    {
        Task<RetornoPadrao> BuscarTodosProdutos(int pageIndex, int pageSize, string? sortColumn = null, string? sortOrder = null, string? filterColumn = null, string? filterQuery = null);
        Task<RetornoPadrao> BuscarProdutoPorId(int id);
        Task<RetornoPadrao> EditarProduto(Produtos produto);
        Task<RetornoPadrao> CadastrarProduto(Produtos produto);
        Task<RetornoPadrao> DeletarProduto(int id);
    }
}
