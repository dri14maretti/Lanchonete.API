using Lanchonete.Business.Ports.In;
using Lanchonete.Business.Ports.Out;
using Lanchonete.Business.UseCases;
using Lanchonete.SqlClient.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Lanchonete.Infra.IoC
{
    
    public static class InjecaoDependencia
    {
        private static string? _conexaoSQL { get; set; }

        public static void InicializarPropriedadesDeInjecao(this IConfiguration configuration)
        {
            _conexaoSQL = configuration.GetConnectionString("SqlServerConnection");
        }

        public static void AdicionarInjecaoNegocio(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioUseCase, UsuarioUseCase>();
            services.AddScoped<IProdutoUseCase, ProdutoUseCase>();
            services.AddScoped<IPedidoUseCase, PedidoUseCase>();
            services.AddScoped<IIngredienteUseCase, IngredienteUseCase>();
            services.AddScoped<IEnderecoUseCase, EnderecoUseCase>();
            
            // Sql Server
            if (string.IsNullOrEmpty(_conexaoSQL)) throw new NotImplementedException("Erro ao injetar as propriedades: connection string inválida");

            services.AddTransient<IDbConnection>((sp) => new SqlConnection(_conexaoSQL));
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IIngredienteRepository, IngredienteRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
        }
    }
}
