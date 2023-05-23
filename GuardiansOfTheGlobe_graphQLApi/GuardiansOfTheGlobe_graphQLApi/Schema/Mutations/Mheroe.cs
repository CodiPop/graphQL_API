using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Mutation
{
    [ExtendObjectType("Mutation")]
    public class Mheroe
    {
        

        public async Task<Hero> SaveHeroAsync([Service] AppDbContext context,
    string Nombre, int edad,  string habilidades, string debilidades, string relacionespersonales)

        {
            var heroe = new Hero();
            heroe.Nombre = Nombre;
            heroe.Edad = edad; 
            heroe.Habilidades = habilidades; 
            heroe.Debilidades = debilidades;
            heroe.RelacionesPersonales = relacionespersonales;
            context.Heroes.Add(heroe);
            await context.SaveChangesAsync();
            return heroe;
        }


        public bool EliminarHeroe([Service] AppDbContext context, int id)
        {
            var registro = context.Heroes.FirstOrDefault(r => r.Id == id);

            if (registro != null)
            {
                context.Heroes.Remove(registro);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<Hero> ActualizarHeroeAsync([Service] AppDbContext context, int id, string nombre, int edad, string habilidades, string debilidades, string relacionespersonales)
        {
            var heroe = await context.Heroes.FirstOrDefaultAsync(r => r.Id == id);

            if (heroe != null)
            {
                heroe.Nombre = nombre;
                heroe.Edad = edad;
                heroe.Habilidades = habilidades;
                heroe.Debilidades = debilidades;
                heroe.RelacionesPersonales = relacionespersonales;
                await context.SaveChangesAsync();
                return heroe;
            }

            return null;
        }


    }
}
