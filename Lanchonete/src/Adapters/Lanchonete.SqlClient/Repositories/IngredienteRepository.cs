using Dapper;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using System.Data;

namespace Lanchonete.SqlClient.Repositories
{
    public class IngredienteRepository : OperacoesBaseRepository<Ingrediente>, IIngredienteRepository
    {
        public IngredienteRepository(IDbConnection connection) : base(connection) { }

        public override async Task<bool> Apagar(int id)
        {
            var sql = "DELETE FROM Lanchonete.dbo.Ingrediente WHERE Id = @id";

            await _connection.ExecuteAsync(sql, new { id });

            return true;
        }

        public override async Task<Ingrediente> Buscar(int id)
        {
            var sql = "SELECT * FROM Lanchonete.dbo.Ingrediente WHERE Id = @id";

            return await _connection.QueryFirstOrDefaultAsync<Ingrediente>(sql, new { id });
        }

        public override async Task Inserir(Ingrediente ingrediente)
        {
            var sql = "INSERT INTO Lanchonete.dbo.Ingrediente VALUES(@Nome, @Validade, @Quantidade);SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var id = await _connection.ExecuteAsync(sql, ingrediente);

            ingrediente.Id = id;
        }

        public async Task<IEnumerable<Ingrediente>> BuscarPorNome(string nome)
        {
            var sql = "SELECT Nome FROM Lanchonete.dbo.Ingrediente WHERE Nome = @nome";

            return await _connection.QueryAsync<Ingrediente>(sql, new { nome });
        }
    }
}
