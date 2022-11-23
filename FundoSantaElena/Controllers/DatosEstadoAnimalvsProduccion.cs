using Microsoft.AspNetCore.Mvc;
using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FundoSantaElena.Controllers
{


    public class DatosEstadoAnimalvsProduccion : Controller
    {
        private readonly AplicationDbContext _context;

        public DatosEstadoAnimalvsProduccion(AplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {

            IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales;
            IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal;
            
            IEnumerable<Animal> animales = _context.Animales;

            ViewBag.Animales = animales;
            ViewBag.ProduccionAnimales = produccionAnimales;
            ViewBag.EventoAnimal = eventoAnimales;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProduccionAnimal pAnimales)
        {
            string fechas = Request.Form["Fecha"];
            Debug.WriteLine("name->"+ fechas);


            IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw("SELECT [Id],[Fecha],[Cantidad],[IdAnimal]" +
                "FROM[FundoSantaElena].[dbo].[ProduccionAnimales]" +
                "WHERE Fecha = '" + fechas + "'").ToList();
            IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal.FromSqlRaw("SELECT TOP (1000) [Id],[Fecha],[Detalles],[IdAnimal]" +
                "FROM[FundoSantaElena].[dbo].[EventoAnimal]" +
                "WHERE FECHA = '" + fechas + "'").ToList();
            IEnumerable<Animal> animales = _context.Animales;

            ViewBag.Animales = animales;
            ViewBag.ProduccionAnimales = produccionAnimales;
            ViewBag.EventoAnimal = eventoAnimales;

            return View();

        }
    }
}
