using ANDERSONDFM.Compartilhado.Interfaces;
using ANDERSONDFM.Compartilhado.Notifications;

namespace ANDERSONDFM.Aplicacao.Requests
{
    public abstract class BaseRequest : Notifiable<Notification>
    {
        public int? UsuarioLogado { get; private set; }

        public BaseRequest(ICurrentUserService currentUserService)
        {
            UsuarioLogado = currentUserService.UsuarioLogado;
        }
    }
}
