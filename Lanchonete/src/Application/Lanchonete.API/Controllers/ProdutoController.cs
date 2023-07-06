using Lanchonete.Business.Filters;
using Lanchonete.Business.Ports.In;
using Lanchonete.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoUseCase produtoUseCase;

        public ProdutoController(IProdutoUseCase produtoUseCase)
        {
            this.produtoUseCase = produtoUseCase;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Buscar(int? id = null, string? nome = null)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produtoFiltro = new ProdutoFiltro()
            {
                Id = id,
                Nome = nome
            };

            var produto = await produtoUseCase.Buscar(produtoFiltro);
            return Ok(produto);
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Inserir([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await produtoUseCase.Inserir(produto);

            return Ok(produto);
        }
        [HttpDelete("{produtoId}")]
        [Produces("application/json")]
        public async Task<IActionResult> Apagar(int produtoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await produtoUseCase.Apagar(produtoId);

            return NoContent();
        }
        [HttpPatch]
        [Produces("application/json")]
        public async Task<IActionResult> Atualizar([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await produtoUseCase.Atualizar(produto);

            return Ok(produto);
        }
    }
}
