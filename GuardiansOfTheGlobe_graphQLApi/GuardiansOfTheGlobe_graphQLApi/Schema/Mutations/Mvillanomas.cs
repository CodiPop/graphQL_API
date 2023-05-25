using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Mutations
{

    [ExtendObjectType("Mutation")]
    public class Mvillanomas
    {
        public Villanomas ObtenerVillanoConMasPeleas([Service] AppDbContext context,int idHeroe)
        {
            var idHeroeParameter = new SqlParameter("@id_heroe", idHeroe);

            var query = context.Villanomas
                .FromSqlRaw("EXEC ObtenerVillanoConMasPeleas @id_heroe", idHeroeParameter)
                .AsEnumerable();

            var result = query.FirstOrDefault();

            return result;

        }
    }
}
