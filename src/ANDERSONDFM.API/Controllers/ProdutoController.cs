using ANDERSONDFM.Aplicacao.Interfaces;
using ANDERSONDFM.Aplicacao.ViewModels.Auth;
using ANDERSONDFM.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANDERSONDFM.API.Controllers
{
    [ApiController]
    [Authorize(Roles = UserRoles.User)]
    [AllowAnonymous]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            int pageIndex = 0,
            int pageSize = 10,
            string? sortColumn = null,
            string? sortOrder = null,
            string? filterColumn = null,
            string? filterQuery = null)
        {
            var result = await _produtoAppService.GetAllProdutcsAsync(
                pageIndex,
                pageSize,
                sortColumn,
                sortOrder,
                filterColumn,
                filterQuery);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutcId(int id)
        {
            var result = await _produtoAppService.FindIdProdutcAsync(id);
            return Ok(result);
        }



    }
}
