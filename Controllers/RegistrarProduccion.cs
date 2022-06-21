using Microsoft.AspNetCore.Mvc;
using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using System.Diagnostics;

namespace FundoSantaElena.Controllers
{
    public class RegistrarProduccion : Controller
    {
        private readonly AplicationDbContext _context;
        public RegistrarProduccion(AplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales;
            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.ProduccionAnimales = produccionAnimales;
            ViewBag.Animales = animales;
            return View();
        }
        //Http post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProduccionAnimal prodAnimal)
        {
            Debug.WriteLine(prodAnimal.Cantidad);
            Debug.WriteLine(prodAnimal.IdAnimal);
            Debug.WriteLine(prodAnimal.Fecha);
            Debug.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
                _context.ProduccionAnimales.Add(prodAnimal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Editar(int? id)
        {
            IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales;
            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.ProduccionAnimales = produccionAnimales;
            ViewBag.Animales = animales;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var prodAnimal = _context.ProduccionAnimales.Find(id);
            if (prodAnimal == null)
            {
                return NotFound();
            }
            return View(prodAnimal);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ProduccionAnimal prodAnimal)
        {
            if (ModelState.IsValid)
            {
                _context.ProduccionAnimales.Update(prodAnimal);
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
            var prodAnimal = _context.ProduccionAnimales.Find(id);
            if (prodAnimal == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.ProduccionAnimales.Remove(prodAnimal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}