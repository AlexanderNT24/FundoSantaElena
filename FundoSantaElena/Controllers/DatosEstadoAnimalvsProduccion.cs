using Microsoft.AspNetCore.Mvc;
using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FundoSantaElena.Controllers
{


    public class DatosEstadoAnimalvsProduccion : Controller
    {
        private readonly AplicationDbContext _context;

        public DatosEstadoAnimalvsProduccion(AplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {

            IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales;
            IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal;

            IEnumerable<Animal> animales = _context.Animales;

            ViewBag.Animales = animales;
            ViewBag.ProduccionAnimales = produccionAnimales;
            ViewBag.EventoAnimal = eventoAnimales;
            ViewBag.FiltroFecha = "";
            ViewBag.FiltroAnimal = "";
            ViewBag.Post = false;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProduccionAnimal pAnimales)
        {
            string fechas = Request.Form["Fecha"];
            Debug.WriteLine("fechas->" + fechas);
            IEnumerable<Animal> animales = _context.Animales;
            Debug.WriteLine(pAnimales.IdAnimal);
            ViewBag.Animales = animales;
            ViewBag.FiltroFecha = fechas;
            ViewBag.Post = true;
            if (fechas != "")
            {
                
                if (pAnimales.IdAnimal!=0)
                {
                    double totalProduccionAnimal = 0;
                    string sqlProd = "SELECT [Id],[Fecha],[Cantidad],[IdAnimal]" +
                        "FROM[FundoSantaElena].[dbo].[ProduccionAnimales] " +
                        "WHERE Fecha = '" + fechas + "' AND IdAnimal=" + pAnimales.IdAnimal;
                    string sqlEvento = "SELECT TOP (1000) [Id],[Fecha],[Detalles],[IdAnimal]" +
                        "FROM[FundoSantaElena].[dbo].[EventoAnimal]" +
                        "WHERE Fecha = '" + fechas + "' AND IdAnimal=" + pAnimales.IdAnimal;
                    Debug.WriteLine("Prod->" + sqlProd);
                    Debug.WriteLine("Evento->" + sqlEvento);

                    IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw(sqlProd).ToList();
                    IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal.FromSqlRaw(sqlEvento).ToList();

                    foreach (var item in produccionAnimales)
                    {
                        totalProduccionAnimal = item.Cantidad + totalProduccionAnimal;
                    }
                    pAnimales.Animal = _context.Animales.Find(pAnimales.IdAnimal);
                    
                    ViewBag.ProduccionAnimales = produccionAnimales;
                    ViewBag.EventoAnimal = eventoAnimales;

                    
                    ViewBag.FiltroAnimal = "Para: " + pAnimales.Animal.Nombre;
                }
                else
                {
                    IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw("SELECT [Id],[Fecha],[Cantidad],[IdAnimal]" +
                        "FROM[FundoSantaElena].[dbo].[ProduccionAnimales]" +
                        "WHERE Fecha = '" + fechas + "'").ToList();
                    IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal.FromSqlRaw("SELECT TOP (1000) [Id],[Fecha],[Detalles],[IdAnimal]" +
                        "FROM[FundoSantaElena].[dbo].[EventoAnimal]" +
                        "WHERE FECHA = '" + fechas + "'").ToList();

                    ViewBag.ProduccionAnimales = produccionAnimales;
                    ViewBag.EventoAnimal = eventoAnimales;

                    ViewBag.FiltroAnimal = "";

                }
            }
            else
            {
                double totalProduccionAnimal = 0;
                IEnumerable<ProduccionAnimal> produccionAnimales = _context.ProduccionAnimales.FromSqlRaw("SELECT [Id],[Fecha],[Cantidad],[IdAnimal]" +
                    "FROM[FundoSantaElena].[dbo].[ProduccionAnimales] " +
                    "WHERE IdAnimal=" + pAnimales.IdAnimal).ToList();
                IEnumerable<EventoAnimal> eventoAnimales = _context.EventoAnimal.FromSqlRaw("SELECT TOP (1000) [Id],[Fecha],[Detalles],[IdAnimal]" +
                    "FROM[FundoSantaElena].[dbo].[EventoAnimal]" +
                    "WHERE IdAnimal=" + pAnimales.IdAnimal).ToList();

                foreach (var item in produccionAnimales)
                {
                    totalProduccionAnimal = item.Cantidad + totalProduccionAnimal;
                }
                pAnimales.Animal = _context.Animales.Find(pAnimales.IdAnimal);

                ViewBag.ProduccionAnimales = produccionAnimales;
                ViewBag.EventoAnimal = eventoAnimales;
                ViewBag.FiltroAnimal = "Para: " + pAnimales.Animal.Nombre;
                ViewBag.FiltroFecha = "";
            }



            return View();

        }
    }
}
