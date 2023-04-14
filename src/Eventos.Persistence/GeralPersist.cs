using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;
using Eventos.Persistence.Contextos;
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

        void IGeralPersist.Add<T>(T entity)
        {
            _context.Add(entity);
        }

        void IGeralPersist.Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        void IGeralPersist.DeleteRange<T>(T[] entityArray)
        {
           _context.RemoveRange(entityArray);
        }

          async Task<bool> IGeralPersist.SaveChangeAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;
        }

        void IGeralPersist.Update<T>(T entity)
        {
            _context.Update(entity);
        }

    }
}