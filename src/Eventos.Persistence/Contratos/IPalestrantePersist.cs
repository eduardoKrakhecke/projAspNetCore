using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;

namespace Eventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {

        //palestrantes
         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEvento);

        Task<Palestrante[]> GetAllEPalestrantesAsync(bool includeEvento);

        Task<Palestrante> GetEPalestranteByIdAsync(int PalestranteId, bool includeEvento);
    }
}