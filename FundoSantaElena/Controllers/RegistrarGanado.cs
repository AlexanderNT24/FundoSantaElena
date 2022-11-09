using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Dynamic;

namespace FundoSantaElena.Controllers
{
    public class RegistrarGanado : Controller
    {

        private readonly AplicationDbContext _context;
        public RegistrarGanado(AplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {

            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.Animal = animales;
            ViewBag.Registrar = false;
            return View();
        }

        //Http post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Animales.Add(animal);
                _context.SaveChanges();
                IEnumerable<Animal> animales = _context.Animales;
                ViewBag.Animal = animales;
                ViewBag.Registrar = true;
                return View();
            }
            ViewBag.Registrar = false;
            return View();
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var animal = _context.Animales.Find(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Animales.Update(animal);
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
            var animal = _context.Animales.Find(id);
            if (animal == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Animales.Remove(animal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
