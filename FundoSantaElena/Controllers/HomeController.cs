﻿using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FundoSantaElena.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AplicationDbContext _context;

        public HomeController(AplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            IEnumerable<Animal> animales = _context.Animales;
            ViewBag.Animales = animales;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}