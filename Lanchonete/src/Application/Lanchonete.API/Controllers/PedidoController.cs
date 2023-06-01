using Lanchonete.Business.Filters;
using Lanchonete.Business.Ports.In;
using Lanchonete.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private IProdutoUseCase produtoUseCase;

        public PedidoController(IProdutoUseCase produtoUseCase)
        {
            this.produtoUseCase = produtoUseCase;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Buscar(int id, string nome)
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

            return Ok(true);
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
