using ANDERSONDFM.Aplicacao.Interfaces;
using ANDERSONDFM.Aplicacao.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ANDERSONDFM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] GetProdutoRequest request, [FromServices] IProdutoAppService handler)
        {
            if (request.IsValid == false)
                return BadRequest(request.Notifications);

            var result = await handler.Handle(request);

            if (result == null || result.Count <= 0)
                return NoContent();

            return Ok(result);
        }


    }
}
