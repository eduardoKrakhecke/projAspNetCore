using System.Threading.Tasks;
using Eventos.Domain;

public interface IEventoService 
{
    Task<Evento>AddEventos(Evento model);
    Task<Evento>UpdateEvento(int eventoId, Evento model);
    Task<bool>DeleteEvento(int eventoId);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrant = false);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrant = false);

        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrant = false);
}