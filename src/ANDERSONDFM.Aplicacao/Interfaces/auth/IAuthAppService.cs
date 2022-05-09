using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANDERSONDFM.Aplicacao.ViewModels;
using ANDERSONDFM.Compartilhado.ViewModel;

namespace ANDERSONDFM.Aplicacao.Interfaces.auth
{
    public interface IAuthAppService
    {
        Task<RetornoPadrao> CadastrarUsuario(UsuarioAuth usuarioAuth);
    }
}
