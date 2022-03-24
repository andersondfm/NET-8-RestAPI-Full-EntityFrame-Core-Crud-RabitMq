using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANDERSONDFM.Aplicacao.Requests;
using ANDERSONDFM.Compartilhado.ViewModel;

namespace ANDERSONDFM.Aplicacao.Interfaces
{
    public interface IProdutoAppService
    {
        Task<IList<RetornoPadrao>> Handle(GetProdutoRequest request);
    }
}
