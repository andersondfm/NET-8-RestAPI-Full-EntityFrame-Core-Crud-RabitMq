using ANDERSONDFM.Aplicacao.ViewModels;
using ANDERSONDFM.Compartilhado.ViewModel;

namespace ANDERSONDFM.Aplicacao.Interfaces.auth
{
    public interface IAuthAppService
    {
        Task<RetornoPadrao> CadastrarUsuario(UsuarioAuth usuarioAuth);
        Task<RetornoPadrao> CadastrarGestorEstabelecimento(UsuarioAuth usuarioAuth);
        Task<RetornoPadrao> CadastrarUsuariosEstabelecimento(UsuarioAuth usuarioAuth);
    }
}
