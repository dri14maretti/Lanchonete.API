using Lanchonete.Business.Filters;
using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.In
{
    public interface IUsuarioUseCase
    {
        Task Inserir(Usuario usuario);
        Task Apagar(int id);
        Task<Usuario> Buscar(UsuarioFiltro filtro);
        Task Atualizar(Usuario usuario);
    }
}
