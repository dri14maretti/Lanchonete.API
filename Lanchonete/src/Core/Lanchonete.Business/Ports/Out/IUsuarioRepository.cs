using Lanchonete.Business.Filters;
using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.Out
{
    public interface IUsuarioRepository : IOperacoesBaseRepository<Usuario>
    {
        Task<Usuario> Buscar(UsuarioFiltro usuarioFiltro);
    }
}
