using Dapper;
using Lanchonete.Business.Filters;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using System.Data;

namespace Lanchonete.SqlClient.Repositories
{
    public class ProdutoRepository : OperacoesBaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IDbConnection dbConnection) : base(dbConnection) { }

        public override async Task<bool> Apagar(int id)
        {
            var sql = "UPDATE Lanchonete.dbo.Produto SET Status = 0 WHERE Id = @id";

            await _connection.ExecuteAsync(sql, new { id });

            return true;
        }

        public override Task<bool> Atualizar(Produto objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produto>> Buscar(ProdutoFiltro filtro)
        {
            var condicoes = new List<string>();
            var parametros = new DynamicParameters();

            if (filtro.Id != null)
            {
                condicoes.Add($"Id = @Id");
                parametros.Add("@Id", filtro.Id, DbType.Int64);
            }

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                condicoes.Add("Nome = @Nome");
                parametros.Add("@Nome", filtro.Nome, DbType.String);
            }

            var where = condicoes.Count > 0 ? $" WHERE {string.Join(" AND ", condicoes.ToArray())}" : "";

            var sql = $@"SELECT * FROM Lanchonete.dbo.Produto {where}";

            try
            {
                var produtosRetornados = await _connection.QueryAsync<Produto>(sql, parametros);
                return produtosRetornados;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                throw new Exception(ex.ToString());
            }
        }

        public override Task<Produto> Buscar(int id)
        {
            var sql = @"SELECT * FROM Lanchonete.dbo.Produto WHERE Id = @id";

            return _connection.QueryFirstOrDefaultAsync<Produto>(sql, id);
        }

        public override async Task Inserir(Produto produto)
        {
            var insert = "INSERT INTO Lanchonete.dbo.Produto VALUES(@Nome, @Descricao, @Valor, 1) SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var produtoId = (await _connection.QueryAsync<int>(insert, produto)).Single();

            produto.Id = produtoId;
        }
    }
}
