using Microsoft.AspNetCore.Mvc;
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
    public class RegistrarVentaController : Controller
    {
        private readonly AplicationDbContext _context;
        public RegistrarVentaController(AplicationDbContext context)
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
        public IActionResult Index(VentaProduccion produccion)
        {
            if (ModelState.IsValid)
            {
                _context.VentaProduccion.Add(produccion);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
