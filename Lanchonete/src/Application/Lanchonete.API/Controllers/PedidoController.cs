
using Lanchonete.Business.Ports.In;
using Lanchonete.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private IPedidoUseCase pedidoUseCase;

        public PedidoController(IPedidoUseCase pedidoUseCase)
        {
            this.pedidoUseCase = pedidoUseCase;
        }
        [HttpGet()]
        [Produces("application/json")]
        public async Task<IActionResult> Buscar(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pedido = await pedidoUseCase.Buscar(id);
            return Ok(pedido);
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Inserir([FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await pedidoUseCase.Inserir(pedido);

            return Ok(pedido);
        }
        [HttpDelete]
        [Produces("application/json")]
        public async Task<IActionResult> Apagar([FromQuery] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await pedidoUseCase.Apagar(id);

            return NoContent();
        }
    }
}
