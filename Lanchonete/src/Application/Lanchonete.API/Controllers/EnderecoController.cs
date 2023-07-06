using Lanchonete.Business.Ports.In;
using Lanchonete.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private IEnderecoUseCase enderecoUseCase;

        public EnderecoController(IEnderecoUseCase enderecoUseCase)
        {
            this.enderecoUseCase = enderecoUseCase;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Buscar(int usuarioId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingrediente = await enderecoUseCase.Buscar(usuarioId);
            return Ok(ingrediente);
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Inserir([FromBody] Endereco endereco)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await enderecoUseCase.Inserir(endereco);

            return Ok(endereco);
        }
        [HttpDelete]
        [Produces("application/json")]
        public async Task<IActionResult> Apagar([FromQuery] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await enderecoUseCase.Apagar(id);

            return NoContent();
        }
        [HttpPatch]
        [Produces("application/json")]
        public async Task<IActionResult> Atualizar([FromBody] Endereco endereco)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await enderecoUseCase.Atualizar(endereco);

            return Ok();
        }
    }
}
