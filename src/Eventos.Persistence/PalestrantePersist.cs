using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;
using Eventos.Persistence.Contextos;
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


        public async Task<Palestrante> GetEventoByIdAsync(int EventoId, bool includePalestrant = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
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

        public async Task<Palestrante> GetPalestranteByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            return await query.FirstOrDefaultAsync();
        }

        Task<Palestrante[]> IPalestrantePersist.GetAllEPalestrantesAsync(bool includeEvento)
        {
            throw new NotImplementedException();
        }

        Task<Palestrante[]> IPalestrantePersist.GetAllPalestrantesByNomeAsync(string nome, bool includeEvento)
        {
            throw new NotImplementedException();
        }

        Task<Palestrante> IPalestrantePersist.GetEPalestranteByIdAsync(int PalestranteId, bool includeEvento)
        {
            throw new NotImplementedException();
        }
    }
}