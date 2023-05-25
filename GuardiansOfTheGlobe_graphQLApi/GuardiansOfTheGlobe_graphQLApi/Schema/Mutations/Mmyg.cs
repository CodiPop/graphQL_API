using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobe_graphQLApi.Models;
using GuardiansOfTheGlobeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Mutations
{
    [ExtendObjectType("Mutation")]
    public class Mmyg
    {

        public List<MyG> ExecMyG([Service] AppDbContext context)
        {
            // Llamado al procedimiento almacenado utilizando Entity Framework Core
            var results = context.Myg.FromSqlRaw("EXEC ObtenerMyG").ToList();

            return results;
        }
    }
}
