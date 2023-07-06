using Lanchonete.Domain.Entities;

namespace Lanchonete.API.RequestObjects
{
    public class UsuarioRequest
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }

        public static explicit operator Usuario(UsuarioRequest request)
        {
            return new Usuario(request.CPF, request.Nome, request.Telefone, request.Senha);
        }
    }
}
