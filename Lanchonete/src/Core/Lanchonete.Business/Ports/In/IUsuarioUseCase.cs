using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.In
{
    public interface IUsuarioUseCase
    {
        Task Inserir(Usuario usuario);
        Task Apagar(int id);
        Task<Usuario> Buscar(int id);
        Task Atualizar(Usuario usuario);
    }
}
