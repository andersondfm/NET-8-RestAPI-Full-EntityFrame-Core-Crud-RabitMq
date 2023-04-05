using ANDERSONDFM.Aplicacao.Interfaces;
using ANDERSONDFM.Aplicacao.ViewModels.Auth;
using ANDERSONDFM.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANDERSONDFM.API.Controllers
{
    [ApiController]
    [Authorize(Roles = UserRoles.User)]
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
            var result = await _produtoAppService.BuscarTodosProdutos(
                pageIndex,
                pageSize,
                sortColumn,
                sortOrder,
                filterColumn,
                filterQuery);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> Get(int id)
        {
            var result = await _produtoAppService.BuscarProdutoPorId(id);
            if (result.data == null)
            {
                return NoContent();
            }
            return Ok(result.data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Produtos produtos)
        {
            if (id != produtos.Id)
            {
                return BadRequest();
            }

            var result = await _produtoAppService.EditarProduto(produtos);
            return Ok(result);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<Produtos>> Post(Produtos produto)
        {
            var result = await _produtoAppService.CadastrarProduto(produto);
            return CreatedAtAction("Get", new { id = result.Id }, result );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _produtoAppService.DeletarProduto(id);
            if (result.excluido)
            {
                return Ok(result.Mensagens);
            }
            result.Mensagens = new List<string> { "Não foi possível excluir o produto. Id: " + id + " (O Id do produto não está na Base de Dados.)" };
            return NotFound(result.Mensagens);
        }

    }
}
