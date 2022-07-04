using System.ComponentModel.DataAnnotations;

namespace FundoSantaElena.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nombre obligatorio")]
        [StringLength(maximumLength:50,ErrorMessage ="El {0} debe ser minimo {2} y maximo {1} caracteres",MinimumLength  =5)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Contraseña obligatoria")]
        [StringLength(maximumLength: 200, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 5)]
        public string Contrasenia { get; set; }
    }
}
