using ANDERSONDFM.Dominio.Entidades;
using ANDERSONDFM.Dominio.Interfaces;
using ANDERSONDFM.Infra.Contextos;
using ANDERSONDFM.Infra.Repositorio.Base;
using Microsoft.EntityFrameworkCore;

namespace ANDERSONDFM.Infra.Repositorio.Negocio
{
    public class ProdutoRepositorio : RepositoryBase<Produtos>, IProdutoRepositorio
    {
        private readonly Contexto _contexto;
        public ProdutoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<ApiResult<Produtos>> BuscarTodosProdutos(int pageIndex, int pageSize, string? sortColumn,
            string? sortOrder, string? filterColumn,
            string? filterQuery)
        {
            return await ApiResult<Produtos>.CreateAsync(
                    _contexto.Produtos.AsNoTracking(),
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }
    }
}
