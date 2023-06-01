using Lanchonete.Business.Filters;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using System.Data;

namespace Lanchonete.SqlClient.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IDbConnection _connection;

        public UsuarioRepository(IDbConnection connection)
        {
            _connection = connection;
        }

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

        public Task<Usuario> Buscar(UsuarioFiltro usuarioFiltro)
        {
            throw new NotImplementedException();
        }

        public Task<int> Inserir(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
