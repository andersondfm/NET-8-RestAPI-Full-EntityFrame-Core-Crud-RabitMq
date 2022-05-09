using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANDERSONDFM.Aplicacao.Interfaces.auth;
using ANDERSONDFM.Aplicacao.ViewModels;
using ANDERSONDFM.Compartilhado.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Update;

namespace ANDERSONDFM.Aplicacao.Servicos.auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthAppService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public Task<RetornoPadrao> cadastrarUsuario(UsuarioAuth usuarioAuth)
        {
            var result = new RetornoPadrao();

            try
            {
                var user = new IdentityUser { UserName = usuarioAuth.Nome, Email = usuarioAuth.Email };
                var data = userManager.CreateAsync(user, usuarioAuth.Password).Result;
                result.Dados = data;
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
