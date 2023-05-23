using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Query
{

    [ExtendObjectType("Query")]
    public class Qvillano
    {

        public List<Villano> Getvillanos([Service] AppDbContext context)
        {
            return context.Villanos.ToList();
        }
    }
}
