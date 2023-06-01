using Lanchonete.Business.Filters;
using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.Out
{
    public interface IProdutoRepository : IOperacoesBaseRepository<Produto>
    {
        Task<Produto> Buscar(ProdutoFiltro filtro);
    }
}
