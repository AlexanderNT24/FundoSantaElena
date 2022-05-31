using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundoSantaElena.Models
{
    public class ProduccionAnimal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Fecha obligatoria")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 5)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Cantidad obligatoria")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 5)]
        public double Cantidad { get; set; }
        [ForeignKey("Id")]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
