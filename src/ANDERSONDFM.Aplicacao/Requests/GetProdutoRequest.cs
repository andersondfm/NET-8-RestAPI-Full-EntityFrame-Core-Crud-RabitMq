using ANDERSONDFM.Aplicacao.Requests;
using ANDERSONDFM.Compartilhado.Interfaces;

namespace ANDERSONDFM.Aplicacao.Requests
{
    public class GetProdutoRequest : BaseRequest
    {
        public GetProdutoRequest(ICurrentUserService currentUserService) : base(currentUserService)
        {

        }
    }


}
