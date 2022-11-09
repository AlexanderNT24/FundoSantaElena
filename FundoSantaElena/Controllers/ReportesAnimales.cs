using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FundoSantaElena.Controllers
{
    public class ReportesAnimales : Controller
    {
        private readonly AplicationDbContext _context;
        public ReportesAnimales(AplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.Animal = animales;
            ViewBag.EventoAnimal = null;
            return View();
        }

        //Http post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Animal animal)
        {
            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.Animal = animales;

            Debug.WriteLine("ID: : " + animal.Id);
            var sql = "SELECT Animales.Id,Animales.Id as IdAnimal,EventoAnimal.Fecha,EventoAnimal.Detalles FROM Animales INNER JOIN EventoAnimal ON EventoAnimal.IdAnimal = Animales.Id WHERE Animales.Id = '" + animal.Id + "'";
            IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal.FromSqlRaw(sql).ToList();
            Debug.WriteLine("evento:: " + sql);
            foreach (var eventoAnimal in eventoAnimales)
            {
                Debug.WriteLine("Detalle: " + eventoAnimal.Detalles);
            }
            ViewBag.EventoAnimal = eventoAnimales;

            return View();

        }
    }
}
