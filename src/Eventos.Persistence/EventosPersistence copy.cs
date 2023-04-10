using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;
using Eventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly EventosContext _context;
        public PalestrantePersist(EventosContext context)
        {
            _context = context;
        }


        async Task<Evento> IEventosPersistence.GetEventoByIdAsync(int EventoId, bool includePalestrant = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if(includePalestrant) {
                query = query.
                Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Id == EventoId);
            return await query.FirstOrDefaultAsync();
        }
    }
}