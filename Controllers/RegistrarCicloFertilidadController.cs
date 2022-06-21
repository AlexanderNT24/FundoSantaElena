using Microsoft.AspNetCore.Mvc;
using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Dynamic;


namespace FundoSantaElena.Controllers
{
    public class RegistrarCicloFertilidadController : Controller
    {
        private readonly AplicationDbContext _context;
        public RegistrarCicloFertilidadController(AplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.Animales = animales;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(EventoAnimal evanimal)
        {
            if (ModelState.IsValid)
            {
                _context.EventoAnimal.Add(evanimal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
