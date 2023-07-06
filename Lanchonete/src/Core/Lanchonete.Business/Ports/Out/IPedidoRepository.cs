using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.Out
{
    public interface IPedidoRepository : IOperacoesBaseRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> BuscarPorUsuarioId(int clienteId);
        Task<IEnumerable<Pedido>> BuscarPorProdutoId(int produtoId);
        Task<IEnumerable<Pedido>> BuscarPorEnderecoId(int enderecoId);
    }
}
