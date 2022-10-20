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
            venta.Precio = "11";
            float numero;
            Assert.AreEqual(true, float.TryParse(venta.Precio,out numero));

        }
        [Test]
        public void TestVenta2()
        {
            var venta = new VentaProduccion();
            venta.Precio = "1m00";
            float numero;
            Assert.AreEqual(false, float.TryParse(venta.Precio, out numero));

        }
        [Test]
        public void TestVenta3()
        {
            var venta = new VentaProduccion();
            venta.Precio = "25";
            float numero;
            Assert.AreEqual(true, float.TryParse(venta.Precio, out numero));

        }
    }
}