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

        public Task<RetornoPadrao> ObterTodosProdutos()
        {
            var result = new RetornoPadrao();

            try
            {
                var data = _produtoRepositorio.SelecionarTodos().ToList();
                result.Dados = data.Select(x => new Produtos()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    DataInclusao = x.DataInclusao,
                    UsuarioInclusao = x.UsuarioInclusao
                });
                result.Mensagens = new List<string> { "OK" };
                return Task.FromResult(result);
            }
            catch (Exception)
            {
                result.Mensagens = new List<string> {"Houve um erro ao Buscar Produtos."};
                return Task.FromResult(result);
            }
        }
    }
}
