using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.In
{
    public interface IPedidoUseCase
    {
        Task Inserir(Pedido pedido);
        Task Apagar(int id);
        Task<Pedido> Buscar(int id);
    }
}
