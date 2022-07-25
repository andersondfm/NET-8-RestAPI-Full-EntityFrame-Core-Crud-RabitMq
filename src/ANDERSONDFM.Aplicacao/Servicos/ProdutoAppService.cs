using ANDERSONDFM.Aplicacao.Interfaces;
using ANDERSONDFM.Compartilhado.ViewModel;
using ANDERSONDFM.Dominio.Entidades;
using ANDERSONDFM.Dominio.Interfaces;

namespace ANDERSONDFM.Aplicacao.Servicos
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoAppService(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<RetornoPadrao> GetAllProdutcsAsync(int pageIndex, int pageSize, string? sortColumn = null, string? sortOrder = null,
            string? filterColumn = null, string? filterQuery = null)
        {
            var result = new RetornoPadrao();

            try
            {
                //Método sem async e sem paginação
                //var data = _produtoRepositorio.SelecionarTodos().ToList();
                
                var lista = await _produtoRepositorio.BuscarTodosProdutos(
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);


                result.data = lista.Data.Select(x => new Produtos()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    DataInclusao = x.DataInclusao,
                    UsuarioInclusao = x.UsuarioInclusao
                });

                result.PageIndex = lista.PageIndex;
                result.PageSize = lista.PageSize;
                result.TotalCount = lista.TotalCount;
                result.TotalPages = lista.TotalPages;
                result.HasPreviousPage = lista.HasPreviousPage;
                result.HasNextPage = lista.HasNextPage;
                

                
                result.Mensagens = new List<string> { "OK" };
                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                result.Mensagens = new List<string> {"Houve um erro ao Buscar Produtos."};
                return await Task.FromResult(result);
            }
        }

        public async Task<RetornoPadrao> FindIdProdutcAsync(int id)
        {
            var result = new RetornoPadrao();
            var lista = await _produtoRepositorio.ObterPorIdAsync(id);

            result.data = new Produtos()
            {
                Id = lista.Id,
                Nome = lista.Nome,
                DataInclusao = lista.DataInclusao,
                UsuarioInclusao = lista.UsuarioInclusao
            };

            return result;
        }
    }
}
