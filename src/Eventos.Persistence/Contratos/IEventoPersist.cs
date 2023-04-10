using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;

namespace Eventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
        //Eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrant);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrant);

        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrant);

    }
}