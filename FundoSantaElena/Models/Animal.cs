using System.ComponentModel.DataAnnotations;

namespace FundoSantaElena.Models
{
    public class Animal 
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre obligatorio")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 5)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Fecha Nacimiento obligatorio")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 5)]
        public string FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Sexo obligatorio")]
        [StringLength(maximumLength: 1, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 1)]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Foto obligatoria")]
        [StringLength(maximumLength: 1000, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 5)]
        public string Foto { get; set; }
        [Required(ErrorMessage = "Raza obligatoria")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 5)]
        public string Raza { get; set; }


    }
}
