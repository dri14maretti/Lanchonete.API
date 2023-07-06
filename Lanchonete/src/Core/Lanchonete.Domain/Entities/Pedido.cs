using System.ComponentModel.DataAnnotations;

namespace Lanchonete.Domain.Entities
{
    public class Pedido
    {
        [Key]
        public int? Id { get; set; } 
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public IEnumerable<int> ItensPedido { get; set; }
        public int EnderecoId { get; set; } 
        public float Valor { get; set; } 
        public int FormaPagamentoId { get; set; } 
        public DateTime Data { get; set; }
        public int StatusId { get; set; } 
    }
}
