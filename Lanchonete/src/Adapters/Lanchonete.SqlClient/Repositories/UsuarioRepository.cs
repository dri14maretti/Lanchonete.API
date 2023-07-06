using Dapper;
using Lanchonete.Business.Filters;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Domain.Entities;
using System.Data;

namespace Lanchonete.SqlClient.Repositories
{
    public class UsuarioRepository : OperacoesBaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IDbConnection dbConnection) : base(dbConnection) {}
        public async Task<Usuario> Buscar(UsuarioFiltro usuarioFiltro)
        {
            var condicoes = new List<string>();
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(usuarioFiltro.CPF))
            {
                condicoes.Add($"CPF = @CPF");
                parametros.Add("@CPF", usuarioFiltro.CPF, DbType.String);
            }

            if (!string.IsNullOrEmpty(usuarioFiltro.Nome))
            {
                condicoes.Add("Nome = @Nome");
                parametros.Add("@Nome", usuarioFiltro.Nome, DbType.String);
            }

            var where = condicoes.Count > 0 ? $" WHERE {string.Join(" AND ", condicoes.ToArray())}" : "";

            var sql = $@"SELECT * FROM Lanchonete.dbo.Usuario {where}";

            try
            {
                var usuarioRetornado = await _connection.QueryFirstOrDefaultAsync<Usuario>(sql, parametros);
                return usuarioRetornado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                throw new Exception(ex.ToString());
            }

        }

        public override async Task<bool> Apagar(int id)
        {
            var sql = "DELETE FROM Lanchonete.dbo.Usuario WHERE Id = @Id";

            var retorno = await _connection.QueryAsync<Usuario>(sql, new { Id = id });

            return true;
        }

        public override async Task<bool> Atualizar(Usuario usuario)
        {
            var sql = @"UPDATE Lanchonete.dbo.Usuario 
                            SET Nome = @Nome, CPF = @CPF, Telefone = @Telefone, Senha = @Senha
                        WHERE Id = @Id";

            await _connection.QueryAsync(sql, usuario);

            return true;
        }

        public override Task<Usuario> Buscar(int id)
        {
            var sql = @"SELECT * FROM Lanchonete.dbo.Usuario WHERE Id = @id";

            return _connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { id });
        }

        public override async Task Inserir(Usuario usuario)
        {
            var insert = "INSERT INTO Lanchonete.dbo.Usuario VALUES(@Nome, @CPF, @Telefone, @Senha, 1) SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var usuarioId = (await _connection.QueryAsync<int>(insert, usuario)).Single();

            usuario.Id = usuarioId;
            usuario.Status = true;
        }
    }
}
