using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Dynamic;

namespace FundoSantaElena.Controllers
{
    public class RegistrarEstadoGanadoController : Controller
    {
        private readonly AplicationDbContext _context;
        public RegistrarEstadoGanadoController(AplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.Animales = animales;
            IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal;
            ViewBag.EventoAnimal = eventoAnimales;
            ViewBag.Registrar = false;
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

                IEnumerable<Animal> animales = _context.Animales;
                ViewBag.Animales = animales;
                IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal;
                ViewBag.EventoAnimal = eventoAnimales;
                ViewBag.Registrar = true;
                return View();
            }
            return View();
        }
        public IActionResult Editar(int? id)
        {
            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.Animales = animales;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var evanimal = _context.EventoAnimal.Find(id);
            if (evanimal == null)
            {
                return NotFound();
            }
            return View(evanimal);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(EventoAnimal evanimal)
        {
            if (ModelState.IsValid)
            {
                _context.EventoAnimal.Update(evanimal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var evanimal = _context.EventoAnimal.Find(id);
            if (evanimal == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.EventoAnimal.Remove(evanimal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
