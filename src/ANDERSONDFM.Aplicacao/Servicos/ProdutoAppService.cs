using ANDERSONDFM.Aplicacao.Interfaces;
using ANDERSONDFM.Aplicacao.Requests;
using ANDERSONDFM.Compartilhado.ViewModel;

namespace ANDERSONDFM.Aplicacao.Servicos
{
    public class ProdutoAppService : IProdutoAppService
    {
        public Task<IList<RetornoPadrao>> Handle(GetProdutoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
