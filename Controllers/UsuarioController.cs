using FundoSantaElena.Datos;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FundoSantaElena.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AplicationDbContext _context;
        public UsuarioController(AplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(Usuarios usuario)
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
                                RedirectToAction("../RegistrarGanado");
                            }
                        }

                    }
                
                
            }


            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        //Http post create
        [HttpPost]
        public IActionResult Create(Usuarios usuario)
        {
            Debug.WriteLine(usuario.Nombre);
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
