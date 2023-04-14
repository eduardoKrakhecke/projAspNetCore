
using System;
using System.Threading.Tasks;
using Eventos.Domain;
using Eventos.Persistence.Contratos;

public class EventoService : IEventoService
{
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

    public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
    {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;
        
    }
    public async Task<Evento> AddEventos(Evento model)
    {
        try
        {
            _geralPersist.Add<Evento>(model);
            if(await _geralPersist.SaveChangeAsync())
            {
               return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
            }
            return null;

        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento> UpdateEvento(int eventoId, Evento model)
    {
        try
        {
            var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
            if(evento == null) return null;

            model.Id = eventoId;

            _geralPersist.Update(model);
             if(await _geralPersist.SaveChangeAsync())
            {
               return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
            }
            return null;


        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

   public async Task<bool> DeleteEvento(int eventoId)
    {
         try
        {
            var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
            if(evento == null) throw new Exception("Evento para delete não encontrado");

            _geralPersist.Delete(evento);
             return await _geralPersist.SaveChangeAsync();
         


        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento[]> GetAllEventosAsync(bool includePalestrant)
    {
        try
        {
            var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrant);
            if(eventos == null)
            {
                return null;
            }
            return eventos;
        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrant)
    {
        try
        {
            var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrant);
            if(eventos == null)
            {
                return null;
            }
            return eventos;
        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrant)
    {
        try
        {
            var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrant);
            if(eventos == null)
            {
                return null;
            }
            return eventos;
        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

}