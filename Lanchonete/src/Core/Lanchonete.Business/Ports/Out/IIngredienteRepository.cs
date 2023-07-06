using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.Out
{
    public interface IIngredienteRepository : IOperacoesBaseRepository<Ingrediente>
    {
        Task<IEnumerable<Ingrediente>> BuscarPorNome(string nome);
    }
}
