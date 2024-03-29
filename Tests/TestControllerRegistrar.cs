﻿using FundoSantaElena.Controllers;
using FundoSantaElena.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;


namespace Tests
{

    public class TestControllerRegistro
    {

        [Test]
        public void TestIndex()
        {

            var optionsBuilder = new DbContextOptionsBuilder<AplicationDbContext>();
            var context = new Mock<AplicationDbContext>(optionsBuilder.Options);
            var controller = new RegistrarGanado(context.Object);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}