using Lanchonete.Business.Filters;
using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.Ports.In
{
    public interface IProdutoUseCase
    {
        Task Inserir(Produto produto);
        Task Apagar(int id);
        Task<Produto> Buscar(ProdutoFiltro filtro);
        Task Atualizar(Produto produto);
    }
}
