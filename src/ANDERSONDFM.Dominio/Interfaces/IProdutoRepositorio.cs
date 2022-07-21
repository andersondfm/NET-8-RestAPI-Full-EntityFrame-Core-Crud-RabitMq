
using ANDERSONDFM.Dominio.Entidades;
using ANDERSONDFM.Dominio.Interfaces.Base;

namespace ANDERSONDFM.Dominio.Interfaces
{
    public interface IProdutoRepositorio : IRepositoryBase<Produtos>
    {
        Task<ApiResult<Produtos>> BuscarTodosProdutos(int pageIndex, int pageSize, string? sortColumn,
            string? sortOrder,
            string? filterColumn, string? filterQuery);
    }
}
