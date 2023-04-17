using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;

namespace Eventos.Persistence.Contratos
{
    public interface IGeralPersist
    {
        //GERAL
        public void Add<T>(T entity) where T : class;
        public  void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public void DeleteRange<T>(T[] entity) where T : class;
        public Task<bool> SaveChangesAsync();
    }
}