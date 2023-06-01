using Lanchonete.Business.Filters;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using System.Data;

namespace Lanchonete.SqlClient.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> BuscarPorClienteId(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Inserir(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
