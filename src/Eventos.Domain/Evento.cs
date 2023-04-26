using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain.Identity;

namespace Eventos.Domain
{
  
    //[Table("evento_tabela")]
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }

        public string DataEvento { get; set; }

       // [Required]
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImageURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}