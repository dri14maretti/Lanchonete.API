using Lanchonete.Business.Ports.In;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using Lanchonete.Domain.Enum;

namespace Lanchonete.Business.UseCases
{
    public class PedidoUseCase : IPedidoUseCase
    {
        private IPedidoRepository pedidoRepository { get; set; }

        public PedidoUseCase(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }
        
        public async Task Apagar(int id)
        {
            await VerificarTempoStatusPedido(id);

            await pedidoRepository.Apagar(id); 
        }

        public async Task<Pedido> Buscar(int id)
        {
            return await pedidoRepository.Buscar(id);
        }

        public async Task Inserir(Pedido pedido)
        {
            await pedidoRepository.Inserir(pedido);
        }

        private async Task VerificarTempoStatusPedido(int id)
        {
            var pedido = await pedidoRepository.Buscar(id);
            if(pedido.Data.Subtract(DateTime.Now) > TimeSpan.FromMinutes(5))
            {
                throw new Exception("O pedido foi realizado a mais de 5 minutos");
            }
            if(pedido.StatusId >= (int)StatusPedido.EmPreparacao)
            {
                throw new Exception("O status do pedido já se encontra em um estágio impassível de cancelamento");
            }
        }
    }
}
