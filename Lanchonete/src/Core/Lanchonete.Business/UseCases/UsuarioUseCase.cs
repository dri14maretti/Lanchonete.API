using Lanchonete.Business.Ports.In;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.UseCases
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private IUsuarioRepository usuarioRepository;
        
        public UsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
        
        public async Task Atualizar(Usuario usuario)
        {
            await usuarioRepository.Atualizar(usuario);
        }

        public async Task<Usuario> Buscar(int id)
        {
            var usuarioRetornado = await usuarioRepository.Buscar(id);
            return usuarioRetornado;
        }

        public async Task Inserir(Usuario usuario)
        {
            await usuarioRepository.Inserir(usuario);
        }

        public async Task Apagar(int id)
        {
            await usuarioRepository.Apagar(id);
        }
    }
}
