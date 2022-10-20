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
            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.Animales = animales;
            ViewBag.TotalProduccion = 0;
            ViewBag.TotalVenta = 0;
            ViewBag.TotalVentaCantidad = 0;
            ViewBag.Perdida = 0;
            ViewBag.Post = false;
            ViewBag.ProduccionAnimales = produccionAnimales;
            ViewBag.VentaProduccion = ventaProduccion;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProduccionAnimal pAnimales)
        {
            
            IEnumerable<ProduccionAnimal> produccionAnimal = _context.ProduccionAnimales.FromSqlRaw("SELECT 0 AS Id, Fecha,convert (nvarchar,SUM(convert (int,Cantidad)))as Cantidad,0 AS IdAnimal FROM[FundoSantaElena].[dbo].[ProduccionAnimales] WHERE Fecha ='" + pAnimales.Fecha + "' GROUP BY Fecha").ToList();
            float totalProduccion = 0;
            foreach (var item in produccionAnimal)
            {
                totalProduccion = float.Parse(item.Cantidad);
            }
            IEnumerable<Animal> animales = _context.Animales;
            IEnumerable<VentaProduccion> ventaProduccion = _context.VentaProduccion.FromSqlRaw("SELECT [Id],[Fecha],[Destino],[Cantidad],[Precio] FROM[FundoSantaElena].[dbo].[VentaProduccion] WHERE Fecha = '" + pAnimales.Fecha + "'").ToList();
            ViewBag.VentaProduccion = ventaProduccion;
            IEnumerable<VentaProduccion> venta = _context.VentaProduccion.FromSqlRaw("SELECT 0 AS Id, Fecha,convert (nvarchar,SUM(convert (int,Cantidad)))as Cantidad, convert (nvarchar,SUM(convert (int,Precio)))as Precio ,'' AS Destino FROM[FundoSantaElena].[dbo].[VentaProduccion] WHERE Fecha = '" + pAnimales.Fecha + "' GROUP BY Fecha").ToList();
            float ventaTotal = 0;
            foreach (var item in venta)
            {
                ventaTotal = float.Parse(item.Precio);
            }
            float ventaCantidadTotal = 0;
            foreach (var item in venta)
            {
                ventaCantidadTotal = float.Parse(item.Cantidad);
            }
            float totalProduccionAnimal=0;
            if (pAnimales.IdAnimal == 0)
            {
                IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw("SELECT [Id],[Fecha],[Cantidad],[IdAnimal]FROM[FundoSantaElena].[dbo].[ProduccionAnimales]WHERE Fecha = '" + pAnimales.Fecha + "'").ToList();
                ViewBag.ProduccionAnimales = produccionAnimales;

            }
            else
            {
                IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw("SELECT [Id],[Fecha],[Cantidad],[IdAnimal]FROM[FundoSantaElena].[dbo].[ProduccionAnimales] WHERE Fecha = '" + pAnimales.Fecha + "' AND IdAnimal=" + pAnimales.IdAnimal).ToList();
                ViewBag.ProduccionAnimales = produccionAnimales;
                foreach (var item in produccionAnimales)
                {
                    totalProduccionAnimal = float.Parse(item.Cantidad)+ totalProduccionAnimal;
                }
            }
            ViewBag.TotalProduccionAnimal = totalProduccionAnimal;
            ViewBag.Post = true;
            ViewBag.Animales = animales;
            ViewBag.Perdida = totalProduccion - ventaCantidadTotal;
            ViewBag.TotalVentaCantidad = ventaCantidadTotal;
            ViewBag.TotalVenta = ventaTotal;
            ViewBag.TotalProduccion = totalProduccion;
            Debug.WriteLine("Fecha"+pAnimales.IdAnimal);
            return View();
        }
    }
}
