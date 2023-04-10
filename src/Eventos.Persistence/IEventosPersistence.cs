using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;

namespace Eventos.Persistence
{
    public interface IEventosPersistence
    {
        void Add<T>(T entity) where T: class;

        void Update<T>(T entity) where T: class;

        void Delete<T>(T entity) where T: class;

        void DeleteRange<T>(T[] entity) where T: class;

        Task<bool> SaveChangeAsync();

        //Eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrant);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrant);

        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrant);

        //palestrantes
         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEvento);

        Task<Palestrante[]> GetAllEPalestrantesAsync(bool includeEvento);

        Task<Palestrante> GetEPalestranteByIdAsync(int PalestranteId, bool includeEvento);
    }
}