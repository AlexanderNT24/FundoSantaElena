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

            IEnumerable<VentaProduccion> venta = _context.VentaProduccion;
            ViewBag.VentaProduccion = venta;
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
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var produccion = _context.VentaProduccion.Find(id);
            if (produccion == null)
            {
                return NotFound();
            }
            return View(produccion);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(VentaProduccion produccion)
        {
            if (ModelState.IsValid)
            {
                _context.VentaProduccion.Update(produccion);
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
            var produccion = _context.VentaProduccion.Find(id);
            if (produccion == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.VentaProduccion.Remove(produccion);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
