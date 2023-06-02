using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Mutations
{
    [ExtendObjectType("Mutation")]
    public class Mvillano
    {

        public async Task<Villano> SaveVillanoAsync([Service] AppDbContext context, string nombre, int edad, string habilidades, string origen, string poder, string debilidades)
        {
            var villano = new Villano();
            villano.Nombre = nombre;
            villano.Edad = edad;
            villano.Habilidades = habilidades;
            villano.Origen = origen;
            villano.Poder = poder;
            villano.Debilidades = debilidades;
            context.Villanos.Add(villano);
            await context.SaveChangesAsync();
            return villano;
        }

        public async Task<Villano> UpdateVillanoAsync([Service] AppDbContext context, int id, string nombre, int edad, string habilidades, string origen, string poder, string debilidades)
        {
            var villano = await context.Villanos.FirstOrDefaultAsync(v => v.Id == id);

            if (villano != null)
            {
                villano.Nombre = nombre;
                villano.Edad = edad;
                villano.Habilidades = habilidades;
                villano.Origen = origen;
                villano.Poder = poder;
                villano.Debilidades = debilidades;
                await context.SaveChangesAsync();
                return villano;
            }

            return null;
        }


        public async Task<bool> DeleteVillanoAsync([Service] AppDbContext context, int id)
        {
            var villano = await context.Villanos.FirstOrDefaultAsync(v => v.Id == id);

            if (villano != null)
            {
                context.Villanos.Remove(villano);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
