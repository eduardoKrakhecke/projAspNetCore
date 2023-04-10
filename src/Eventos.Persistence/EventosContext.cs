using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Persistence
{
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> options) : base(options)
        {

        }

        public DbSet<Evento> Eventos { get; set; }//mapeamento de classe para se tornar um banco de dados

        public DbSet<Lote> Lotes { get; set; }

        public DbSet<Palestrante> Palestrantes { get; set; }

        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }

        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<PalestranteEvento>().HasKey(PE => new {PE.EventoId, PE.PalestranteId});
        }
        
    }
}