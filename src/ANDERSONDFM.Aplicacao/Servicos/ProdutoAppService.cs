using ANDERSONDFM.Aplicacao.Interfaces;
using ANDERSONDFM.Compartilhado.ViewModel;
using ANDERSONDFM.Dominio.Entidades;
using ANDERSONDFM.Dominio.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.SqlServer.ValueGeneration.Internal;

namespace ANDERSONDFM.Aplicacao.Servicos
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private ILogger<ProdutoAppService> Logger { get; }


        public ProdutoAppService(IProdutoRepositorio produtoRepositorio, ILogger<ProdutoAppService> logger)
        {
            _produtoRepositorio = produtoRepositorio;
            Logger = logger;
        }

        public async Task<RetornoPadrao> BuscarTodosProdutos(int pageIndex, int pageSize, string? sortColumn = null, string? sortOrder = null,
            string? filterColumn = null, string? filterQuery = null)
        {
            var result = new RetornoPadrao();

            try
            {
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
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                result.Mensagens = new List<string> { "Houve um erro ao Buscar Produtos." };
                return await Task.FromResult(result);
            }
        }

        public async Task<RetornoPadrao> BuscarProdutoPorId(int id)
        {
            var result = new RetornoPadrao();
            var lista = await _produtoRepositorio.ObterPorIdAsync(id);
            if (lista != null)
            {
                result.data = new Produtos()
                {
                    Id = lista.Id,
                    Nome = lista.Nome,
                    DataInclusao = lista.DataInclusao,
                    UsuarioInclusao = lista.UsuarioInclusao
                };
                result.Id = lista.Id;
                return result;
            }

            return result;
        }

        public async Task<RetornoPadrao> EditarProduto(Produtos produto)
        {
            var result = new RetornoPadrao();
            var item = await _produtoRepositorio.AlterarAsync(produto);
            if (item != null)
            {
                result.data = new Produtos()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    DataInclusao = produto.DataInclusao,
                    UsuarioInclusao = produto.UsuarioInclusao
                };
            }
            result.Mensagens = new List<string> { "Alterado com sucesso." };

            return result;
        }

        public async Task<RetornoPadrao> CadastrarProduto(Produtos produto)
        {
            var result = new RetornoPadrao();
            var item = await _produtoRepositorio.InserirAsync(produto);
            if (item)
            {
                result.data = new Produtos()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    DataInclusao = produto.DataInclusao,
                    UsuarioInclusao = produto.UsuarioInclusao
                };
            }

            if (produto.Id != 0)
            {
                result.Id = produto.Id;
            }
            result.Mensagens = new List<string> { "Inserido com sucesso." };

            return result;

        }

        public async Task<RetornoPadrao> DeletarProduto(int id)
        {
            var result = new RetornoPadrao();
            var produto = await _produtoRepositorio.ObterPorIdAsync(id);
            if (produto != null)
            {
                var excluir = await _produtoRepositorio.ExcluirAsync(produto);
                if (excluir)
                {
                    result.excluido = true;
                    result.Mensagens = new List<string> { "Produto Excluido com sucesso." };
                    return result;
                }
            }
            return result;
        }
    }
}
