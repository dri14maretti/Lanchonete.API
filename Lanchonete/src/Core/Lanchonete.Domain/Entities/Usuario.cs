using System.ComponentModel.DataAnnotations;

namespace Lanchonete.Domain.Entities
{
    public class Usuario
    {
        public Usuario() { }
        
        public Usuario(int id, string cpf, string nome, string telefone, string senha, bool status)
        {
            Id = id;
            CPF = cpf;
            Nome = nome;
            Telefone = telefone;
            Senha = senha;
            Status = status;
        }
        
        public Usuario(string cpf, string nome, string telefone, string senha)
        {
            CPF = cpf;
            Nome = nome;
            Telefone = telefone;
            Senha = senha;
        }

        [Key]
        public int? Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public bool? Status { get; set; }

        public void AtribuirId(int id)
        {
            Id = id;
        }

    }
}
