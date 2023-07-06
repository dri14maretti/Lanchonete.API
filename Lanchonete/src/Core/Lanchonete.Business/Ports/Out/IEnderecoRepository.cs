using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.Out
{
    public interface IEnderecoRepository : IOperacoesBaseRepository<Endereco>
    {
        Task<IEnumerable<Endereco>> BuscarPorUsuarioId(int usuarioId);   
    }
}
