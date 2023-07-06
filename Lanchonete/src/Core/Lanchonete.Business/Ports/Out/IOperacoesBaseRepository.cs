namespace Lanchonete.Business.Ports.Out
{
    public interface IOperacoesBaseRepository<T> where T : class
    {
        Task<bool> Apagar(int id);
        Task<bool> Atualizar(T objeto);
        Task<T> Buscar(int id);
        Task Inserir(T objeto);
    }
}
