using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GuardiansOfTheGlobe_graphQLApi.Schema.Mutations
{
    [ExtendObjectType("Mutation")]
    public class Magenda
    {


        public async Task<Agenda> SaveAgendaEntryAsync([Service] AppDbContext context,
                int idHeroe, DateTime fecha, string evento)
        {
            var agendaEntry = new Agenda();
            agendaEntry.IdHeroe = idHeroe;
            agendaEntry.Fecha = fecha;
            agendaEntry.Evento = evento;
            context.Agenda.Add(agendaEntry);
            await context.SaveChangesAsync();
            return agendaEntry;
        }


        public bool EliminarAgendaEntry([Service] AppDbContext context, int id)
        {
            var agendaEntry = context.Agenda.FirstOrDefault(a => a.Id == id);

            if (agendaEntry != null)
            {
                context.Agenda.Remove(agendaEntry);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<Agenda> ActualizarAgendaEntryAsync([Service] AppDbContext context, int id, DateTime fecha, string evento)
        {
            var agendaEntry = await context.Agenda.FirstOrDefaultAsync(a => a.Id == id);

            if (agendaEntry != null)
            {
                agendaEntry.Fecha = fecha;
                agendaEntry.Evento = evento;
                await context.SaveChangesAsync();
                return agendaEntry;
            }

            return null;
        }


    }



}
