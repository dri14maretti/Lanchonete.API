using Lanchonete.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete.Domain.Entities
{
    public class Usuario
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public FuncaoEnum Funcao { get; set; }

    }
}
