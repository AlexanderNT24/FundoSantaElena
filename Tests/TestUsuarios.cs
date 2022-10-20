using FundoSantaElena.Interfaces;
using FundoSantaElena.Models;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class TestsUsuarios
    {
        [Test]
        public void TestUsuarios1()
        {
            var usuario = new Usuarios();
            usuario.Id = 1;
            usuario.Nombre = "Usuario1";
            usuario.Contrasenia = "123_a1";
            var result = usuario.ValidarDatos(usuario);
            Assert.AreEqual(true, result);

        }
        [Test]
        public void TestUsuarios2()
        {
            var usuario = new Usuarios();
            usuario.Id = 0;
            usuario.Nombre = "Usuario2";
            usuario.Contrasenia = "adbs_a1";
            var result = usuario.ValidarDatos(usuario);
            Assert.AreEqual(false, result);

        }
        [Test]
        public void TestUsuarios3()
        {
            var usuario = new Usuarios();
            usuario.Id = 3;
            usuario.Contrasenia = "1a3_a1";
            var result = usuario.ValidarDatos(usuario);
            Assert.AreEqual(false, result);

        }
        [Test]
        public void TestUsuarios4()
        {
            var usuario = new Usuarios();
            usuario.Id = 3;
            usuario.Nombre = "Usuario4";
            usuario.Contrasenia = "1a3_a1";
            var result = usuario.ValidarDatos(usuario);
            Assert.AreEqual(true, result);
        }
    }
}