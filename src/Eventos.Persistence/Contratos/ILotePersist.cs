using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;

namespace Eventos.Persistence.Contratos
{
    public interface ILotePersist
    {
         Task<Lote[]> GetLotesByEventoIdAsync(int eventoId);
         Task<Lote> GetLoteByIdsAsync(int eventoId, int loteId);
    }
}