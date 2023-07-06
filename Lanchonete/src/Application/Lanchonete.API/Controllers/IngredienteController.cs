using Lanchonete.Business.Ports.In;
using Lanchonete.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredienteController : ControllerBase
    {
        private IIngredienteUseCase ingredienteUseCase;

        public IngredienteController(IIngredienteUseCase ingredienteUseCase)
        {
            this.ingredienteUseCase = ingredienteUseCase;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Buscar(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingrediente = await ingredienteUseCase.Buscar(id);
            return Ok(ingrediente);
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Inserir([FromBody] Ingrediente ingrediente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await ingredienteUseCase.Inserir(ingrediente);

            return Ok(ingrediente);
        }
        [HttpDelete]
        [Produces("application/json")]
        public async Task<IActionResult> Apagar([FromQuery] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await ingredienteUseCase.Apagar(id);

            return NoContent();
        }
        [HttpPatch]
        [Produces("application/json")]
        public async Task<IActionResult> Atualizar([FromBody] Ingrediente ingrediente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await ingredienteUseCase.Atualizar(ingrediente);

            return Ok();
        }
    }
}
