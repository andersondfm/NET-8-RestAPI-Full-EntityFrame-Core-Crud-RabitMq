using ANDERSONDFM.Aplicacao.Interfaces.auth;
using ANDERSONDFM.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ANDERSONDFM.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarTask([FromBody] UsuarioAuth usuarioAuth)
        {
            var result = await _authAppService.cadastrarUsuario(usuarioAuth);

            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}
