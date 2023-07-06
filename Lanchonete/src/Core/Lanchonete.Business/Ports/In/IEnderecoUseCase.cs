using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.In
{
    public interface IEnderecoUseCase
    {
        Task Inserir(Endereco endereco);
        Task Apagar(int id);
        Task<IEnumerable<Endereco>> Buscar(int id);
        Task Atualizar(Endereco endereco);
    }
}
