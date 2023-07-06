using DapperExtensions;
using Lanchonete.Business.Ports.Out;
using System.Data;

namespace Lanchonete.SqlClient.Repositories
{
    public abstract class OperacoesBaseRepository<T> : IOperacoesBaseRepository<T> where T : class
    {
        protected IDbConnection _connection;

        public OperacoesBaseRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public virtual Task<bool> Apagar(int id)
        {
            return _connection.DeleteAsync<T>(id);
        }

        public virtual Task<bool> Atualizar(T objeto)
        {
            return _connection.UpdateAsync<T>(objeto);
        }

        public virtual Task<T> Buscar(int id)
        {
            return _connection.GetAsync<T>(id);
        }

        public virtual async Task Inserir(T objeto)
        {
            await _connection.InsertAsync(objeto);
        }
    }
}
