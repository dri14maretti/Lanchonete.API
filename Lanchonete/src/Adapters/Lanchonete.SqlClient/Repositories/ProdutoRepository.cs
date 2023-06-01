using Lanchonete.Business.Filters;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;

namespace Lanchonete.SqlClient.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(Produto objeto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> Buscar(ProdutoFiltro filtro)
        {
            throw new NotImplementedException();
        }

        public Task<int> Inserir(Produto objeto)
        {
            throw new NotImplementedException();
        }
    }
}
