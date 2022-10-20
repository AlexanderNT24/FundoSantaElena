using FundoSantaElena.Interfaces;
using FundoSantaElena.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestEventoAnimal
    {
        //cuando no se pasa el id
        [Test]
        public void TestEventoAnimal1()
        {
            var evento = new EventoAnimal();
            var eve = new Mock<IValidarDatosEventoAnimal>();
            eve.Setup(a => a.ValidarEventos(evento)).Returns(false);
            var obj = new VentaProduccion();
            var result = obj.ValidarEventos(evento);
            Assert.AreEqual(false, result);
        }
        //cuando se pasa el id verdadero
        [Test]
        public void TestEventoAnimal2()
        {
            var evento = new EventoAnimal();
            evento.Id = 10;
            var eve = new Mock<IValidarDatosEventoAnimal>();
            eve.Setup(a => a.ValidarEventos(evento)).Returns(true);
            var obj = new VentaProduccion();
            var result = obj.ValidarEventos(evento);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void TestEventoAnimal3()
        {
            var evento = new EventoAnimal();
            evento.Id = 20;
            var eve = new Mock<IValidarDatosEventoAnimal>();
            eve.Setup(a => a.ValidarEventos(evento)).Returns(true);
            var obj = new VentaProduccion();
            var result = obj.ValidarEventos(evento);
            Assert.AreEqual(true, result);
        }
        //el id no puede ser cero
        [Test]
        public void TestEventoAnimal4()
        {
            var evento = new EventoAnimal();
            evento.Id = 0;
            var eve = new Mock<IValidarDatosEventoAnimal>();
            eve.Setup(a => a.ValidarEventos(evento)).Returns(false);
            var obj = new VentaProduccion();
            var result = obj.ValidarEventos(evento);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void TestEventoAnimal5()
        {
            var evento = new EventoAnimal();
            evento.Id = 100;
            var eve = new Mock<IValidarDatosEventoAnimal>();
            eve.Setup(a => a.ValidarEventos(evento)).Returns(true);
            var obj = new VentaProduccion();
            var result = obj.ValidarEventos(evento);
            Assert.AreEqual(true, result);
        }
    }
}