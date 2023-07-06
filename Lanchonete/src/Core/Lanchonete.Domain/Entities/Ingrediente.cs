using Dapper.Contrib.Extensions;

namespace Lanchonete.Domain.Entities
{
    public class Ingrediente
    {

        [Key]
        public int? Id { get; set; }
        public string Nome { get; set; }
        public DateTime Validade { get; set; }
        public int Quantidade { get; set; }
    }
}
