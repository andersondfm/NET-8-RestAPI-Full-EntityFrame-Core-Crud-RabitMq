using System.Security.Claims;
using ANDERSONDFM.Aplicacao.Interfaces.auth;
using ANDERSONDFM.Aplicacao.ViewModels;
using ANDERSONDFM.Aplicacao.ViewModels.Auth;
using ANDERSONDFM.Compartilhado.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace ANDERSONDFM.Aplicacao.Servicos.auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthAppService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<RetornoPadrao> CadastrarUsuario(UsuarioAuth usuarioAuth)
        {
            var result = new RetornoPadrao();

            try
            {
                var user = new IdentityUser { UserName = usuarioAuth.Nome, Email = usuarioAuth.Email };
                var data = _userManager.CreateAsync(user, usuarioAuth.Password).Result;
                result.data = data;

                if (!data.Succeeded)
                    return await Task.FromResult(result);

                var claimResult = _userManager.AddClaimAsync(user, new Claim("UsuarioPadrao", usuarioAuth.Nome)).Result;
                var roleResult = _roleManager.RoleExistsAsync(UserRoles.User).Result;

                if (!roleResult)
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                await _userManager.AddToRoleAsync(user, UserRoles.User);

                if (!claimResult.Succeeded)
                    return await Task.FromResult(result);

                result.Mensagens = new List<string> { "Cadastro feito com sucesso." };
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                result.Mensagens = new List<string> { "Houve um erro ao Cadastrar o Usuario." + e };
                return await Task.FromResult(result);
            }
        }

        public async Task<RetornoPadrao> CadastrarGestorEstabelecimento(UsuarioAuth usuarioAuth)
        {
            var result = new RetornoPadrao();

            try
            {
                var user = new IdentityUser { UserName = usuarioAuth.Nome, Email = usuarioAuth.Email };
                var data = _userManager.CreateAsync(user, usuarioAuth.Password).Result;
                result.data = data;

                if (!data.Succeeded)
                    return await Task.FromResult(result);

                var claimResult = _userManager.AddClaimAsync(user, new Claim("GestorEstabelecimento", usuarioAuth.Nome)).Result;
                var roleResult = _roleManager.RoleExistsAsync(UserRoles.GestorEstabelecimento).Result;

                if (!roleResult)
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.GestorEstabelecimento));

                await _userManager.AddToRoleAsync(user, UserRoles.GestorEstabelecimento);

                if (!claimResult.Succeeded)
                    return await Task.FromResult(result);

                result.Mensagens = new List<string> { "Cadastro Gestor Estabelecimento feito com sucesso." };
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                result.Mensagens = new List<string> { "Houve um erro ao Cadastrar o Gestor do Estabelecimento." + e };
                return await Task.FromResult(result);
            }
        }

        public async Task<RetornoPadrao> CadastrarUsuariosEstabelecimento(UsuarioAuth usuarioAuth)
        {
            var result = new RetornoPadrao();

            try
            {
                var user = new IdentityUser { UserName = usuarioAuth.Nome, Email = usuarioAuth.Email };
                var data = _userManager.CreateAsync(user, usuarioAuth.Password).Result;
                result.data = data;

                if (!data.Succeeded)
                    return await Task.FromResult(result);

                var claimResult = _userManager.AddClaimAsync(user, new Claim("UsuariosEstabelecimento", usuarioAuth.Nome)).Result;
                var roleResult = _roleManager.RoleExistsAsync(UserRoles.UsuariosEstabelecimento).Result;

                if (!roleResult)
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.UsuariosEstabelecimento));

                await _userManager.AddToRoleAsync(user, UserRoles.UsuariosEstabelecimento);

                if (!claimResult.Succeeded)
                    return await Task.FromResult(result);

                result.Mensagens = new List<string> { "Cadastro Usuários do Estabelecimento feito com sucesso." };
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                result.Mensagens = new List<string> { "Houve um erro ao Cadastrar o Usuários do Estabelecimento." + e };
                return await Task.FromResult(result);
            }
        }
    }
}
