using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FundoSantaElena.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AplicationDbContext _context;
        public UsuarioController(AplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Usuarios> usuarios = _context.Usuarios;
            return View();
        }


        [HttpPost]
        public IActionResult Login(Usuarios usuario)
        {
            IEnumerable<Usuarios> usuarios = _context.Usuarios;

            if (ModelState.IsValid)
            {

                foreach (var usuarioDb in usuarios)
                {
                    if (usuario.Nombre == usuarioDb.Nombre)
                    {
                        if (usuario.Contrasenia == usuarioDb.Contrasenia)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }

                }


            }
    
            return RedirectToAction("Index");

        }

        public IActionResult Create()
        {
            return View();
        }

        //Http post create
        [HttpPost]
        public IActionResult Create(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
