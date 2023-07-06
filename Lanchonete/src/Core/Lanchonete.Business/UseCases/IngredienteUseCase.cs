using Lanchonete.Business.Ports.In;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Lanchonete.Business.UseCases
{
    public class IngredienteUseCase : IIngredienteUseCase
    {
        private IIngredienteRepository ingredienteRepository;

        public IngredienteUseCase(IIngredienteRepository ingredienteRepository)
        {
            this.ingredienteRepository = ingredienteRepository;
        }

        public async Task Apagar(int id)
        {
            var ingrediente = await ingredienteRepository.Buscar(id);

            if (ingrediente.Quantidade > 0) throw new Exception("Ingredientes disponíveis em estoque não podem ser excluídos");

            await ingredienteRepository.Apagar(id);
        }

        public async Task<Ingrediente> Buscar(int id)
        {
            return await ingredienteRepository.Buscar(id);
        }

        public async Task Atualizar(Ingrediente ingrediente)
        {
            var ingredienteAntigo = await ingredienteRepository.Buscar(ingrediente.Id ?? 0);

            if (ingredienteAntigo.Nome != ingrediente.Nome) throw new Exception("O ingrediente não pode ter um nome diferente");

            await ingredienteRepository.Atualizar(ingrediente);
        }

        public async Task Inserir(Ingrediente ingrediente)
        {
            var ingredientesNome = await ingredienteRepository.BuscarPorNome(ingrediente.Nome);

            if(ingredientesNome.Any())
            {
                throw new Exception("Já existe um ingrediente cadastrado com o mesmo nome");
            }

            await ingredienteRepository.Inserir(ingrediente);
        }
    }
}
