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

        public DatosVentavsProduccion(AplicationDbContext context)
        {
           _context = context;

        }

        public IActionResult Index()
        {

            IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.ToList();
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

            ViewBag.FiltroFecha = "";
            ViewBag.FiltroAnimal= "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProduccionAnimal pAnimales)
        {
            string fechasVanilla = Request.Form["Fecha"];
            ViewBag.FiltroAnimal = "";
            var fechas = fechasVanilla.Split('/');
            //var fechas = Convert.ToString(pAnimales.Fecha).Split('/');
            Debug.WriteLine("Entrada->" + fechasVanilla);
            // pAnimales.Fecha
            if(fechasVanilla=="" && pAnimales.IdAnimal!=0)
            {
                double totalProduccionAnimal = 0;
                var sqlAnimalProd = "SELECT [Id],[Fecha],[Cantidad],[IdAnimal]" +
                        "FROM[FundoSantaElena].[dbo].[ProduccionAnimales] " +
                        "WHERE IdAnimal=" + pAnimales.IdAnimal;
                Debug.WriteLine("AnimalProd->" + sqlAnimalProd);
                var sqlAnimal = "SELECT [Id],[Nombre],[FechaNacimiento],[Sexo],[Foto],[Raza]" +
                        "FROM[FundoSantaElena].[dbo].[Animales] " +
                        "WHERE [Id]=" + pAnimales.IdAnimal;
                Debug.WriteLine("AnimalProd->" + sqlAnimal);
                IEnumerable<Animal> animales = _context.Animales;
                IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw(sqlAnimalProd).ToList();
                IEnumerable<VentaProduccion> ventaProduccion = _context.VentaProduccion;
                ViewBag.ProduccionAnimales = produccionAnimales;
                foreach (var item in produccionAnimales)
                {
                    totalProduccionAnimal = item.Cantidad + totalProduccionAnimal;
                }
                pAnimales.Animal = _context.Animales.Find(pAnimales.IdAnimal);
                ViewBag.FiltroAnimal = "Para: " + pAnimales.Animal.Nombre;

                ViewBag.Animales = animales;
                ViewBag.TotalProduccion = 0;
                ViewBag.TotalVenta = 0;
                ViewBag.TotalVentaCantidad = 0;
                ViewBag.Perdida = 0;
                ViewBag.Post = true;
                ViewBag.ProduccionAnimales = produccionAnimales;
                ViewBag.VentaProduccion = ventaProduccion;
                ViewBag.TotalProduccionAnimal = totalProduccionAnimal;
                ViewBag.FiltroFecha = "";


                return View();
            }


            if (fechas.Length > 1)
            {
                var fechaActual = fechas[1];
                var fechaRango = fechas[0];
                string sql1 = "SELECT 0 AS Id, convert (datetime,'') as Fecha, ISNULL(SUM(Cantidad), 0 ) as Cantidad,0 AS IdAnimal " +
                    "FROM[FundoSantaElena].[dbo].[ProduccionAnimales] " +
                    "WHERE [Fecha] BETWEEN '" 
                    + fechaRango + "' AND '" + fechaActual + "'";
                Debug.WriteLine("Sql1->" + sql1);
                var produccionAnimal = _context.ProduccionAnimales.FromSqlRaw(sql1).ToList();
                double totalProduccion = 0;

                foreach (var item in produccionAnimal)
                {
                    totalProduccion = item.Cantidad;
                }
                IEnumerable<Animal> animales = _context.Animales;
                IEnumerable<VentaProduccion> ventaProduccion = _context.VentaProduccion.FromSqlRaw("SELECT [Id],[Fecha],[Destino],[Cantidad],[Precio] FROM[FundoSantaElena].[dbo].[VentaProduccion] WHERE [Fecha] BETWEEN '" + fechaRango + "' AND '" + fechaActual + "'").ToList();
                ViewBag.VentaProduccion = ventaProduccion;
                string sql2 = "SELECT 0 AS Id, convert (datetime,'') AS Fecha, ISNULL(SUM(Cantidad), 0 ) as Cantidad, ISNULL(SUM(Precio*Cantidad), 0 ) as Precio ,'' AS Destino" +
                    " FROM[FundoSantaElena].[dbo].[VentaProduccion]" +
                    " WHERE [Fecha] BETWEEN'"
                    + fechaRango + "' AND '" + fechaActual + "'";
                Debug.WriteLine("Sql2->" + sql2);
                //Aca
                IEnumerable<VentaProduccion> venta = _context.VentaProduccion.FromSqlRaw(sql2).ToList();

                double ventaTotal = 0;
                foreach (var item in venta)
                {
                    ventaTotal = item.Precio;
                }
                double ventaCantidadTotal = 0;
                foreach (var item in venta)
                {
                    ventaCantidadTotal = item.Cantidad;
                }
                double totalProduccionAnimal = 0;
                if (pAnimales.IdAnimal == 0)
                {
                    IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw("SELECT [Id],[Fecha],[Cantidad],[IdAnimal]" +
                        "FROM[FundoSantaElena].[dbo].[ProduccionAnimales]" +
                        "WHERE [Fecha] BETWEEN '" + fechaRango + "' AND '" + fechaActual + "'").ToList();
                    ViewBag.ProduccionAnimales = produccionAnimales;
                    
                    
                }
                else
                {
                    IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw("SELECT [Id],[Fecha],[Cantidad],[IdAnimal]" +
                        "FROM[FundoSantaElena].[dbo].[ProduccionAnimales] " +
                        "WHERE Fecha BETWEEN '" + fechaRango + "' AND '" + fechaActual + "' AND IdAnimal=" + pAnimales.IdAnimal).ToList();
                    ViewBag.ProduccionAnimales = produccionAnimales;
                    foreach (var item in produccionAnimales)
                    {
                        totalProduccionAnimal = item.Cantidad + totalProduccionAnimal;
                    }
                    pAnimales.Animal = _context.Animales.Find(pAnimales.IdAnimal);
                    ViewBag.FiltroAnimal = "Para: " + pAnimales.Animal.Nombre;
                }
                ViewBag.TotalProduccionAnimal = totalProduccionAnimal;
                ViewBag.Post = true;
                ViewBag.Animales = animales;

                ViewBag.Perdida = totalProduccion - ventaCantidadTotal;
                ViewBag.TotalVentaCantidad = ventaCantidadTotal;
                ViewBag.TotalVenta = ventaTotal;
                ViewBag.TotalProduccion = totalProduccion;
                ViewBag.FiltroFecha = "Desde: "+ fechaRango + " hasta: "+ fechaActual;

            }

            else
            {
                IEnumerable<ProduccionAnimal> produccionAnimal = _context.ProduccionAnimales.FromSqlRaw("SELECT 0 AS Id, convert (datetime,'') AS Fecha, SUM(Cantidad) as Cantidad,0 AS IdAnimal " +
                    "FROM[FundoSantaElena].[dbo].[ProduccionAnimales] " +
                    "WHERE Fecha ='" + fechasVanilla +
                    "' GROUP BY Fecha").ToList();
                double totalProduccion = 0;
                foreach (var item in produccionAnimal)
                {
                    totalProduccion = item.Cantidad;
                }
                IEnumerable<Animal> animales = _context.Animales;
                IEnumerable<VentaProduccion> ventaProduccion = _context.VentaProduccion.FromSqlRaw("SELECT [Id],[Fecha],[Destino],[Cantidad],[Precio] FROM[FundoSantaElena].[dbo].[VentaProduccion] " +
                    "WHERE Fecha = '" + fechasVanilla + "'").ToList();
                ViewBag.VentaProduccion = ventaProduccion;
                IEnumerable<VentaProduccion> venta = _context.VentaProduccion.FromSqlRaw("SELECT 0 AS Id, convert (datetime,'') AS Fecha,SUM(Cantidad) as Cantidad, SUM(Precio * Cantidad) as Precio ,'' AS Destino " +
                    "FROM[FundoSantaElena].[dbo].[VentaProduccion] " +
                    "WHERE Fecha = '" + fechasVanilla + "' " +
                    "GROUP BY Fecha").ToList();

                double ventaTotal = 0;
                foreach (var item in venta)
                {
                    ventaTotal = item.Precio;
                }
                double ventaCantidadTotal = 0;
                foreach (var item in venta)
                {
                    ventaCantidadTotal = item.Cantidad;
                }
                double totalProduccionAnimal = 0;
                if (pAnimales.IdAnimal == 0)
                {
                    IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw("SELECT [Id],[Fecha],[Cantidad],[IdAnimal]" +
                        "FROM[FundoSantaElena].[dbo].[ProduccionAnimales]" +
                        "WHERE Fecha = '" + fechasVanilla + "'").ToList();
                    ViewBag.ProduccionAnimales = produccionAnimales;
                   
                }
                else
                {
                    IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw("SELECT [Id],[Fecha],[Cantidad],[IdAnimal]" +
                        "FROM[FundoSantaElena].[dbo].[ProduccionAnimales] " +
                        "WHERE Fecha = '" + fechasVanilla + "' AND IdAnimal=" + pAnimales.IdAnimal).ToList();
                    ViewBag.ProduccionAnimales = produccionAnimales;
                    foreach (var item in produccionAnimales)
                    {
                        totalProduccionAnimal = item.Cantidad + totalProduccionAnimal;
                    }
                    pAnimales.Animal = _context.Animales.Find(pAnimales.IdAnimal);
                    ViewBag.FiltroAnimal = "Para: " + pAnimales.Animal.Nombre;
                }
                ViewBag.TotalProduccionAnimal = totalProduccionAnimal;
                ViewBag.Post = true;
                ViewBag.Animales = animales;
                ViewBag.Perdida = totalProduccion - ventaCantidadTotal;
                ViewBag.TotalVentaCantidad = ventaCantidadTotal;
                ViewBag.TotalVenta = ventaTotal;
                ViewBag.TotalProduccion = totalProduccion;
                Debug.WriteLine("Fecha" + pAnimales.IdAnimal);
                ViewBag.FiltroFecha = fechasVanilla;
            }
            
            return View();

        }
    }
}
