using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;
using Eventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly EventosContext _context;
        public GeralPersist(EventosContext context)
        {
            _context = context;
        }

        void IEventosPersistence.Add<T>(T entity)
        {
            _context.Add(entity);
        }

        void IEventosPersistence.Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        void IEventosPersistence.DeleteRange<T>(T[] entityArray)
        {
           _context.RemoveRange(entityArray);
        }

          async Task<bool> IEventosPersistence.SaveChangeAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;
        }

        void IEventosPersistence.Update<T>(T entity)
        {
            _context.Update(entity);
        }

    }
}