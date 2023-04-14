using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;

namespace Eventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrant = false);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrant = false);

        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrant = false);

    }
}