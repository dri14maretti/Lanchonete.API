using Lanchonete.Business.Filters;
using Lanchonete.Business.Ports.In;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Lanchonete.Business.UseCases
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private IUsuarioRepository usuarioRepository;
        private IPedidoRepository pedidoRepository;

        public UsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task Atualizar(Usuario usuario)
        {

            var usuarioAtual = await usuarioRepository.Buscar(usuario.Id ?? 0);

            if (usuarioAtual.Nome != usuario.Nome)
                throw new Exception("Impossível alterar o nome do usuário");


            await usuarioRepository.Atualizar(usuario);
        }

        public async Task<Usuario> Buscar(UsuarioFiltro filtro)
        {
            var usuarioRetornado = await usuarioRepository.Buscar(filtro);
            return usuarioRetornado;
        }

        public async Task Inserir(Usuario usuario)
        {
            await ValidarCPF(usuario.CPF);
            var usuarioId = await usuarioRepository.Inserir(usuario);

            usuario.AtribuirId(usuarioId);
        }

        public async Task Apagar(int id)
        {
            await VerificarPedidosAtivos(id);

            await usuarioRepository.Apagar(id);
        }

        #region Validações
        private async Task ValidarCPF(string cpf)
        {
            var filtro = new UsuarioFiltro()
            {
                CPF = cpf
            };

            var usuarioRetornado = await usuarioRepository.Buscar(filtro);


            if (usuarioRetornado != null)
                throw new Exception("CPF já possui uma conta cadastrada.");
        }
        private async Task VerificarPedidosAtivos(int idCliente)
        {
            var pedidosCliente = await pedidoRepository.BuscarPorClienteId(idCliente);

            if (pedidosCliente.Any())
                throw new Exception("Não é possível desativar um cliente com pedidos ativos");
        }
        #endregion
    }
}
