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
            return View();
        }
    }
}
