using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Persistence.Contratos
{
    public class EventoPersist : IEventoPersist
    {
        private readonly EventosContext _context;
        public EventoPersist(EventosContext context)
        {
            _context = context;
        }

        async Task<Evento[]> IEventosPersistence.GetAllEventosAsync(bool includePalestrant = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if(includePalestrant) {
                query = query.
                Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        async Task<Evento[]> IEventosPersistence.GetAllEventosByTemaAsync(string tema, bool includePalestrant = false)
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
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
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