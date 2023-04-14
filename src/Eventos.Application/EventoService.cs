
using System.Threading.Tasks;
using Eventos.Domain;

public class EventoService : IEventoService
{
    Task<Evento> IEventoService.AddEventos(Evento model)
    {
        throw new System.NotImplementedException();
    }

    Task<bool> IEventoService.DeleteEvento(int eventoId)
    {
        throw new System.NotImplementedException();
    }

    Task<Evento[]> IEventoService.GetAllEventosAsync(bool includePalestrant)
    {
        throw new System.NotImplementedException();
    }

    Task<Evento[]> IEventoService.GetAllEventosByTemaAsync(string tema, bool includePalestrant)
    {
        throw new System.NotImplementedException();
    }

    Task<Evento> IEventoService.GetEventoByIdAsync(int EventoId, bool includePalestrant)
    {
        throw new System.NotImplementedException();
    }

    Task<Evento> IEventoService.UpdateEvento(int eventoId, Evento model)
    {
        throw new System.NotImplementedException();
    }
}