using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;

namespace Eventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        public Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}