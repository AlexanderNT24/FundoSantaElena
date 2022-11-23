using FundoSantaElena.Interfaces;
using FundoSantaElena.Models;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class TestVenta
    {
        [Test]
        public void TestVenta1()
        {
            var venta = new VentaProduccion();
            venta.Precio = 11;
            float numero;
            Assert.AreEqual(11, venta.Precio);

        }
        [Test]
        public void TestVenta2()
        {
            var venta = new VentaProduccion();
            venta.Precio = 10;
            float numero;
            Assert.AreNotEqual("1m00", venta.Precio);

        }
        [Test]
        public void TestVenta3()
        {
            var venta = new VentaProduccion();
            venta.Precio = 25;
            float numero;
            Assert.AreEqual(25, venta.Precio);

        }
    }
}