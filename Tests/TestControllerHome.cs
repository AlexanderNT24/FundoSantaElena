using FundoSantaElena.Controllers;
using FundoSantaElena.Datos;
using FundoSantaElena.Interfaces;
using FundoSantaElena.Models;
using Microsoft.AspNetCore.Mvc;
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
    public class TestControllerRegistrar
    {
        private readonly AplicationDbContext _context;
        [Test]
        public void Index()
        {
            HomeController controller = new HomeController(_context);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

    }
}