using Lanchonete.Business.Ports.In;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete.Business.UseCases
{
    public class EnderecoUseCase : IEnderecoUseCase
    {
        private IEnderecoRepository enderecoRepository;
        private IPedidoRepository pedidoRepository;

        public EnderecoUseCase(IEnderecoRepository enderecoRepository, IPedidoRepository pedidoRepository)
        {
            this.enderecoRepository = enderecoRepository;
            this.pedidoRepository = pedidoRepository;
        }

        public async Task Apagar(int id)
        {
            var pedidosAssociados = await pedidoRepository.BuscarPorEnderecoId(id);

            if (pedidosAssociados.Any()) throw new Exception("Endereços com pedidos associados não podem ser excluídos");

            await enderecoRepository.Apagar(id);
        }

        public async Task<IEnumerable<Endereco>> Buscar(int id)
        {
            return await enderecoRepository.BuscarPorUsuarioId(id);
        }

        public async Task Atualizar(Endereco endereco)
        {
            var enderecoAntigo = await enderecoRepository.Buscar(endereco.Id);

            if (enderecoAntigo.UsuarioId != endereco.UsuarioId)
                throw new Exception("O usuário não pode ser distinto");

            await enderecoRepository.Atualizar(endereco);
        }

        public async Task Inserir(Endereco endereco)
        {
            await enderecoRepository.Inserir(endereco);
        }
    }
}
