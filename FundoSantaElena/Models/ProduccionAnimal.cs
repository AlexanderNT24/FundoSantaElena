using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FundoSantaElena.Interfaces;

namespace FundoSantaElena.Models
{
    public class ProduccionAnimal : IValidarDatosProduccionAnimal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Fecha obligatoria")]
        //[StringLength(maximumLength: 50, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 5)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Cantidad obligatoria")]
        public double Cantidad { get; set; }
        [Required(ErrorMessage = "Id Animal obligatorio")]
        public int IdAnimal { get; set; }
        [ForeignKey ("IdAnimal")]
        public Animal Animal { get; set; }

        public bool ValidarDatos(Animal animal)
        {

            if (animal.Id == 0) return false;
            return true;
        }
    }
}
