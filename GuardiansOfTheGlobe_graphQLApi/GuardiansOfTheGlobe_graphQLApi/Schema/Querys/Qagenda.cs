using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Query
{
    [ExtendObjectType("Query")]
    public class Qagenda
    {

        public List<Agenda> Getagenda([Service] AppDbContext context)
        {
            return context.Agenda.ToList();
        }
        
    }




}

