﻿using FundoSantaElena.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace FundoSantaElena.Models
{
    public class VentaProduccion: IValidarDatosEventoAnimal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Fecha obligatoria")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Detalles obligatorios")]
        [StringLength(maximumLength: 10, ErrorMessage = "El {0} debe ser minimo {2} y maximo {1} caracteres", MinimumLength = 0)]
        public string Destino { get; set; }
        [Required(ErrorMessage = "Cantidad obligatoria")]
        public double Cantidad { get; set; }
        [Required(ErrorMessage = "Precio obligatorio")]
        public double Precio { get; set; }
        public bool ValidarEventos(EventoAnimal evento)
        {
            if (evento.Id == 0) return false;
            return true;
        }

    }
}
