using System.Security.Claims;
using ANDERSONDFM.Aplicacao.Interfaces.auth;
using ANDERSONDFM.Aplicacao.ViewModels;
using ANDERSONDFM.Compartilhado.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace ANDERSONDFM.Aplicacao.Servicos.auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthAppService(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        public Task<RetornoPadrao> CadastrarUsuario(UsuarioAuth usuarioAuth)
        {
            var result = new RetornoPadrao();

            try
            {
                var user = new IdentityUser { UserName = usuarioAuth.Nome, Email = usuarioAuth.Email };
                var data = _userManager.CreateAsync(user, usuarioAuth.Password).Result;
                result.Dados = data;

                if (!data.Succeeded)
                    return Task.FromResult(result);

                var claimResult = _userManager.AddClaimAsync(user, new Claim("UsuarioPadrao", usuarioAuth.Nome)).Result;

                if (!claimResult.Succeeded)
                    return Task.FromResult(result);

                result.Mensagens = new List<string> { "OK" };
                return Task.FromResult(result);
            }
            catch (Exception e)
            {
                result.Mensagens = new List<string> { "Houve um erro ao Cadastrar o Usuario" + e };
                return Task.FromResult(result);
            }

           
        }
    }
}
