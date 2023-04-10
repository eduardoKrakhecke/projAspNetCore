using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Persistence;
using Eventos.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        private readonly EventosContext _context;
        public EventosController(EventosContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
          return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
          return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
        }

        [HttpPost]
        public string Post()
        {
          return "exemple de post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
          return $"exemple de put = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
          return $"exemple de delete = {id}";
        }
    }
}
