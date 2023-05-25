using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Query
{
    [ExtendObjectType("Query")]
    public class Qheroe
    {

        public List<Hero> Getheroes([Service] AppDbContext context)
        {
            return context.Heroes.ToList();
        }
        public string Test => "Testeo";


    }




}

