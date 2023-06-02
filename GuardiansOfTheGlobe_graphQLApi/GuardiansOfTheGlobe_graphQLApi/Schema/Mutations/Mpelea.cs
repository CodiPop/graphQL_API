using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Mutations
{
    [ExtendObjectType("Mutation")]
    public class Mpelea
    {

        public async Task<Pelea> SavePeleaAsync([Service] AppDbContext context, int idHeroe, int idVillano, string resultado)
        {
            var pelea = new Pelea();
            pelea.IdHeroe = idHeroe;
            pelea.IdVillano = idVillano;
            pelea.Resultado = resultado;
            context.Peleas.Add(pelea);
            await context.SaveChangesAsync();
            return pelea;
        }

        public async Task<Pelea> UpdatePeleaAsync([Service] AppDbContext context, int id, int idHeroe, int idVillano, string resultado)
        {
            var pelea = await context.Peleas.FirstOrDefaultAsync(p => p.Id == id);

            if (pelea != null)
            {
                pelea.IdHeroe = idHeroe;
                pelea.IdVillano = idVillano;
                pelea.Resultado = resultado;
                await context.SaveChangesAsync();
                return pelea;
            }

            return null;
        }


        public async Task<bool> DeletePeleaAsync([Service] AppDbContext context, int id)
        {
            var pelea = await context.Peleas.FirstOrDefaultAsync(p => p.Id == id);

            if (pelea != null)
            {
                context.Peleas.Remove(pelea);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
