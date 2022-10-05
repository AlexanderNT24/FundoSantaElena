using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FundoSantaElena.Controllers
{
    public class DatosVentavsProduccion : Controller
    {

        private readonly AplicationDbContext _context;


        public DatosVentavsProduccion(ILogger<DatosVentavsProduccion> logger, AplicationDbContext context)
        {
           _context = context;

        }

        public IActionResult Index()
        {


            IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales;
            IEnumerable<VentaProduccion> ventaProduccion = _context.VentaProduccion;

            ViewBag.ProduccionAnimales = produccionAnimales;
            ViewBag.VentaProduccion = ventaProduccion;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProduccionAnimal pAnimales)
        {

            IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw("SELECT [Id],[Fecha],[Cantidad],[IdAnimal]FROM[FundoSantaElena].[dbo].[ProduccionAnimales]WHERE Fecha = '"+ pAnimales.Fecha+ "'").ToList();
            IEnumerable<VentaProduccion> ventaProduccion = _context.VentaProduccion.FromSqlRaw("SELECT [Id],[Fecha],[Destino],[Cantidad],[Precio] FROM[FundoSantaElena].[dbo].[VentaProduccion]WHERE Fecha = '" + pAnimales.Fecha + "'").ToList(); ;

            ViewBag.ProduccionAnimales = produccionAnimales;
            ViewBag.VentaProduccion = ventaProduccion;
            return View();
        }
    }
}
