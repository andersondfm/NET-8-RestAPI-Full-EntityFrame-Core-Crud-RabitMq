using ANDERSONDFM.Aplicacao.Interfaces;
using ANDERSONDFM.Compartilhado.ViewModel;

namespace ANDERSONDFM.Aplicacao.Servicos
{
    public class ProdutoAppService : IProdutoAppService
    {
        public async Task<RetornoPadrao> ObterTodosProdutos()
        {
            var result = new RetornoPadrao();
            result.StatusCode = 200;
            return result;
        }
    }
}
