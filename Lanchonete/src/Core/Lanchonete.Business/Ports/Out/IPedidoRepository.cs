using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.Out
{
    public interface IPedidoRepository : IOperacoesBaseRepository<Pedido>
    {
        Task<List<Pedido>> BuscarPorClienteId(int clienteId);
        Task<List<Pedido>> BuscarPorProdutoId(int clienteId);
    }
}
