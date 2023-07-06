using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.In
{
    public interface IIngredienteUseCase
    {
        Task Inserir(Ingrediente ingrediente);
        Task Apagar(int id);
        Task<Ingrediente> Buscar(int id);
        Task Atualizar(Ingrediente ingrediente);
    }
}
