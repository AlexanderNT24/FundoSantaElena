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

            IEnumerable<Animal> animales = _context.Animales.ToList();
            ViewBag.Animales = animales;
            IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal.ToList();
            ViewBag.EventoAnimal = eventoAnimales;
            ViewBag.Registrar = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(EventoAnimal evanimal)
        {
            IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal;
            ViewBag.EventoAnimal = eventoAnimales;
            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.Animales = animales;
            ViewBag.Registrar = true;         
            evanimal.Animal= _context.Animales.Find(evanimal.IdAnimal);

            //Error al necesitar de un animal
            _context.EventoAnimal.Add(evanimal);
            _context.SaveChanges();
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
            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.Animales = animales;
            _context.EventoAnimal.Update(evanimal);
            _context.SaveChanges();
            return RedirectToAction("Index");

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
