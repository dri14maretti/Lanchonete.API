using Dapper;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Lanchonete.SqlClient.Repositories
{
    public class EnderecoRepository : OperacoesBaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(IDbConnection conn) : base(conn) { }
        public override async Task<bool> Apagar(int id)
        {
            var sql = "DELETE FROM Lanchonete.dbo.Endereco WHERE Id = @id";

            await _connection.ExecuteAsync(sql, new { id });

            return true;
        }

        public override async Task<Endereco> Buscar(int id)
        {
            var sql = "SELECT * FROM Lanchonete.dbo.Endereco WHERE Id = @id";

            return await _connection.QuerySingleOrDefaultAsync<Endereco>(sql, new { id });
        }

        public async override Task Inserir(Endereco endereco)
        {
            var sql = "INSERT INTO Lanchonete.dbo.Endereco VALUES (@UsuarioId, @CEP, @Rua, @Bairro, @Cidade, @Estado, @Complemento)";

            await _connection.ExecuteAsync(sql, endereco);
        }
        public async Task<IEnumerable<Endereco>> BuscarPorUsuarioId(int usuarioId)
        {
            var sql = "SELECT * FROM Lanchonete.dbo.Endereco WHERE UsuarioId = @usuarioId";

            return await _connection.QueryAsync<Endereco>(sql, new { usuarioId });
        }
        
    }
}
