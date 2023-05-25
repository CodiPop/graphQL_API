using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobe_graphQLApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Mutations
{
    [ExtendObjectType("Mutation")]
    public class Mhtop3
    {

        public List<Heroestop3> HeroesTop3([Service] AppDbContext context)
        {
            var query = context.Set<Heroestop3>().FromSqlRaw("EXEC ObtenerHeroesConMasVictorias");

            var results = query.ToList();

            return results;
        }

    }
}
