using Microsoft.AspNetCore.Mvc;
using FundoSantaElena.Datos;
using FundoSantaElena.Models;

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
            ViewBag.ProduccionAnimales = produccionAnimales;
            return View();
        }
        //Http post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProduccionAnimal prodAnimal)
        {
            if (ModelState.IsValid)
            {
                _context.ProduccionAnimales.Add(prodAnimal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}