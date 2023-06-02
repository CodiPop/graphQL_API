using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Mutations
{
    [ExtendObjectType("Mutation")]
    public class Mpatrocinador
    {
        public async Task<Patrocinador> SavePatrocinadorAsync([Service] AppDbContext context, int idHeroe, string nombre, double monto, string origenDinero)
        {
            var patrocinador = new Patrocinador();
            patrocinador.IdHeroe = idHeroe;
            patrocinador.Nombre = nombre;
            patrocinador.Monto = monto;
            patrocinador.OrigenDinero = origenDinero;
            context.Patrocinadores.Add(patrocinador);
            await context.SaveChangesAsync();
            return patrocinador;
        }

        public async Task<Patrocinador> UpdatePatrocinadorAsync([Service] AppDbContext context, int id, string nombre, double monto, string origenDinero)
        {
            var patrocinador = await context.Patrocinadores.FirstOrDefaultAsync(p => p.Id == id);

            if (patrocinador != null)
            {
                patrocinador.Nombre = nombre;
                patrocinador.Monto = monto;
                patrocinador.OrigenDinero = origenDinero;
                await context.SaveChangesAsync();
                return patrocinador;
            }

            return null;
        }

        public async Task<bool> DeletePatrocinadorAsync([Service] AppDbContext context, int id)
        {
            var patrocinador = await context.Patrocinadores.FirstOrDefaultAsync(p => p.Id == id);

            if (patrocinador != null)
            {
                context.Patrocinadores.Remove(patrocinador);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }



    }
}
