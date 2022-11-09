using FundoSantaElena.Controllers;
using FundoSantaElena.Datos;
using FundoSantaElena.Interfaces;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests
{
    public class TestControllerUsuarios
    {
        [Test]
        public void TestIndex()
        {

            var optionsBuilder = new DbContextOptionsBuilder<AplicationDbContext>();
            var context = new Mock<AplicationDbContext>(optionsBuilder.Options);
            var controller = new UsuarioController(context.Object);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

        }
    }
}