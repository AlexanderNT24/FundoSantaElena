using FundoSantaElena.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundoSantaElena.Models
{
    public class EventoAnimal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Fecha obligatoria")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Detalles obligatorios")]
        [StringLength(maximumLength: 10, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 0)]
        public string Detalles { get; set; }
        [Required(ErrorMessage = "Id Animal obligatorio")]
        public int IdAnimal { get; set; }
        [ForeignKey("IdAnimal")]
        public Animal Animal { get; set; }

    }
}
