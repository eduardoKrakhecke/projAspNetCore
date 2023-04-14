using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;
using Eventos.Persistence.Contextos;
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


       public async Task<Evento[]> GetAllEventosAsync(bool includePalestrant = false)
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

       public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrant = false)
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

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrant = false)
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