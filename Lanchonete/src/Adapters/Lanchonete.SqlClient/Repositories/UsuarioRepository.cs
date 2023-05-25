using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;

namespace Lanchonete.SqlClient.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(Usuario objeto)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(Usuario objeto)
        {
            throw new NotImplementedException();
        }
    }
}
