using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Query
{

    [ExtendObjectType("Query")]
    public class Qpelea
    {

        public List<Pelea> Getpeleas([Service] AppDbContext context)
        {
            return context.Peleas.ToList();
        }
    }
}
