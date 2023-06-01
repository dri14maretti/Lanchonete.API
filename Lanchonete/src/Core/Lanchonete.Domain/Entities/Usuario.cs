using Lanchonete.Domain.Enums;

namespace Lanchonete.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string cpf, string nome, Endereco endereco, string telefone, string senha)
        {
            CPF = cpf;
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Senha = senha;
        }

        public int? Id { get; private set; }
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string Senha { get; private set; }

        public void AtribuirId(int id)
        {
            Id = id;
        }

    }
}
