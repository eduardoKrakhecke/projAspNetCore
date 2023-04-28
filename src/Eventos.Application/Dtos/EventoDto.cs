using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Application.Dtos
{
    public class EventoDto
    {
        
        public int Id { get; set; }
        public string Local { get; set; }

        [Required]
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3, ErrorMessage ="{0} deve ter no mínimo 4 caracteres.")]
        [MaxLength(50, ErrorMessage ="{0} deve ter no máximo 50 caracteres.")]
        public string Tema { get; set; }

        [Range(1, 120000, ErrorMessage = "Número de pessoas deve ser entre 1 e 120.000")]
        public int QtdPessoas { get; set; }

        public string ImageURL { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Phone(ErrorMessage ="O campo {0} está com o número inválido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        [Display(Name ="e-mail")]
        [EmailAddress(ErrorMessage ="O {0} precisa ser válido.")]
        public string Email { get; set; }
        public int UserId { get; set; }
        public UserDto userDto { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}