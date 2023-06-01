using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete.Domain.Entities
{
    public class Produto
    {
        public Produto(string nome, string descricao, List<Ingrediente> ingredientes, float valor)
        {
            Nome = nome;
            Descricao = descricao;
            Ingredientes = ingredientes;
            Valor = valor;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public List<Ingrediente> Ingredientes { get; private set; }
        public float Valor { get; private set; }
    }
}
