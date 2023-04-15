using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        private readonly IEventoService _eventoService;
  
        public EventosController(IEventoService eventoService )
        {
            _eventoService = eventoService;
   
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
          try
          {
            var eventos = await _eventoService.GetAllEventosAsync(true);
            if( eventos == null) return NotFound("Nenhum evento encontrado");
            return Ok(eventos);

          }
          catch (Exception ex)
          {
            
           return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar os eventos, Erro: {ex.Message}");
          }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           try
          {
            var evento = await _eventoService.GetEventoByIdAsync(id, true);
            if( evento == null) return NotFound("Evento por id não encontrado");
            return Ok(evento);

          }
          catch (Exception ex)
          {
            
           return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar o evento, Erro: {ex.Message}");
          }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
           try
          {
            var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if( evento == null) return NotFound("Eventos por tema não encontrado");
            return Ok(evento);

          }
          catch (Exception ex)
          {
            
           return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar o evento por tema, Erro: {ex.Message}");
          }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
         try
          {
            var evento = await _eventoService.AddEventos(model);
            if( evento == null) return BadRequest("Erro ao tentar adiconar evento.");
            return Ok(evento);

          }
          catch (Exception ex)
          {
            
           return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar adicionar o evento, Erro: {ex.Message}");
          }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int eventoId, Evento model)
        {
          try
          {
            var evento = await _eventoService.UpdateEvento(eventoId, model);
            if( evento == null) return BadRequest("Erro ao atualizar o evento.");
            return Ok(evento);

          }
          catch (Exception ex)
          {
            
           return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar atualizar o evento, Erro: {ex.Message}");
          }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          try
          {
           if(await _eventoService.DeleteEvento(id))
            return Ok("Excluído");
           else 
             return BadRequest("Evento não excluído");

          }
          catch (Exception ex)
          {
            
           return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar deletar o evento, Erro: {ex.Message}");
          }
        }
    }
}
