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
        public string Fecha { get; set; }
        [Required(ErrorMessage = "Cantidad obligatoria")]
        [StringLength(maximumLength: 10, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 0)]
        public string Cantidad { get; set; }
        [Required(ErrorMessage = "Id Animal obligatorio")]
        public int IdAnimal { get; set; }
    }
}
