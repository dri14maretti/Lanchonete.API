using Dapper;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using System.Data;

namespace Lanchonete.SqlClient.Repositories
{
    public class PedidoRepository : OperacoesBaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(IDbConnection conn) : base(conn) { }

        public override async Task<bool> Apagar(int id)
        {
            var sql = "UPDATE Lanchonete.dbo.Pedido SET StatusId = 0 WHERE Id = @id";

            await _connection.ExecuteAsync(sql, new { id });

            return true;
        }

        public override async Task<Pedido> Buscar(int id)
        {
            var sqlPedido = @"SELECT * FROM Lanchonete.dbo.Pedido p 
                        WHERE p.Id = @id";

            var resultado = await _connection.QueryAsync<Pedido>(
                sqlPedido,
                new { id }
            );

            var pedido = resultado.Single();

            var sqlItens = "SELECT ProdutoId FROM Lanchonete.dbo.PedidoXProduto WHERE PedidoId = @id";

            var itens = await _connection.QueryAsync<int>(sqlItens, new { id });

            pedido.ItensPedido = itens;

            return pedido;
        }

        public async Task<IEnumerable<Pedido>> BuscarPorUsuarioId(int usuarioId)
        {
            var sql = @"SELECT Id, UsuarioId, Valor, Nome, Data FROM Lanchonete.dbo.Pedido
                        WHERE UsuarioId = @usuarioId";

            var resultado = await _connection.QueryAsync<Pedido>(
                sql,
                new { usuarioId }
            );

            return resultado;
        }

        public async Task<IEnumerable<Pedido>> BuscarPorProdutoId(int produtoId)
        {
            var sql = @"SELECT * FROM PedidoXProduto WHERE ProdutoId = @produtoId";

            var resultado = await _connection.QueryAsync<Pedido>(
                sql,
                new { produtoId }
            );

            return resultado;
        }

        public async override Task Inserir(Pedido objeto)
        {
            var sqlPedido = @"INSERT INTO Lanchonete.dbo.Pedido VALUES(@UsuarioId, @EnderecoId, @Valor, @FormaPagamentoId, @StatusId, @Nome, @Data) SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var pedidoId = (await _connection.QueryAsync<int>(sqlPedido, objeto)).Single();

            var sqlItens = @"INSERT INTO Lanchonete.dbo.PedidoXProduto VALUES(@pedidoId, @produtoId)";
            foreach (var item in objeto.ItensPedido)
            {
                await _connection.ExecuteAsync(sqlItens, new { pedidoId, produtoId = item });
            }

            objeto.Id = pedidoId;
        }

        public async Task<IEnumerable<Pedido>> BuscarPorEnderecoId(int enderecoId)
        {
            var sql = "SELECT * FROM Lanchonete.dbo.Pedido WHERE EnderecoId = @enderecoId";

            return await _connection.QueryAsync<Pedido>(sql, new { enderecoId });
        }
    }
}
