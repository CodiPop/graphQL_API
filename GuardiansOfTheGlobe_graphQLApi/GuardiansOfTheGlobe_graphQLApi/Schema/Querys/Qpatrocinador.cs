using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Query
{

    [ExtendObjectType("Query")]
    public class Qpatrociandor { 

        public List<Patrocinador> Getpatrocinadores([Service] AppDbContext context)
        {
            return context.Patrocinadores.ToList();
        }
    }
}
