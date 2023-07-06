using Lanchonete.Business.Filters;
using Lanchonete.Business.Ports.In;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;

namespace Lanchonete.Business.UseCases
{
    public class ProdutoUseCase : IProdutoUseCase
    {
        private IProdutoRepository produtoRepository;
        private IPedidoRepository pedidoRepository;
        public ProdutoUseCase(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
        }
        public async Task Apagar(int id)
        {
            await ValidarPedidosComProduto(id);

            await produtoRepository.Apagar(id);
        }

        public async Task Atualizar(Produto produto)
        {
            var produtoAtual = await produtoRepository.Buscar(produto.Id ?? 0);

            if(produtoAtual.Nome != produto.Nome)
                throw new Exception("Impossível alterar o nome do produto");

            await produtoRepository.Atualizar(produto);
        }

        public async Task<IEnumerable<Produto>> Buscar(ProdutoFiltro filtro)
        {
            var produto = await produtoRepository.Buscar(filtro);
            return produto;
        }

        public async Task Inserir(Produto produto)
        {
            await ValidarExistenciaNome(produto.Nome);
            await produtoRepository.Inserir(produto);
        }

        private async Task ValidarExistenciaNome(string nome)
        {
            var filtro = new ProdutoFiltro()
            {
                Nome = nome
            };

            var produtoExiste = (await produtoRepository.Buscar(filtro)).Any();

            if (produtoExiste)
                throw new Exception("Um produto com esse nome já fora cadastrado");
        }
        private async Task ValidarPedidosComProduto(int id)
        {
            var pedidosProduto = await pedidoRepository.BuscarPorProdutoId(id);

            if (pedidosProduto.Any())
                throw new Exception("Não é possível desativar um produto com pedidos ativos");
        }
    }
}
