using System.Threading.Tasks;
using Eventos.Domain;

public interface IEventoService 
{
    public interface IEventoService
    {
        public Task<Evento> AddEventos(Evento model);
        public Task<Evento> UpdateEvento(int eventoId, Evento model);
        public Task<bool> DeleteEvento(int eventoId);

        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        public Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}