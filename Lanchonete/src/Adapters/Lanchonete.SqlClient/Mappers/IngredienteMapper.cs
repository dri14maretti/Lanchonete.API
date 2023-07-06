using DapperExtensions.Mapper;
using Lanchonete.Domain.Entities;

namespace Lanchonete.SqlClient.Mappers
{
    public class IngredienteMapper : ClassMapper<Ingrediente>
    {
        public IngredienteMapper()
        {
            base.Map(m => m.Id).Ignore();
            base.AutoMap();
        }
    }
}
