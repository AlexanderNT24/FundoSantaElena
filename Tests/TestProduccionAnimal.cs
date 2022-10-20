using FundoSantaElena.Interfaces;
using FundoSantaElena.Models;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class TestProduccionAnimal
    {

        [Test]
        public void TestProduccion1()
        {
            var animal = new Animal();
            animal.Id = 1;

            
            var ani = new Mock<IValidarDatosProduccionAnimal>();
            ani.Setup(a => a.ValidarDatos(animal)).Returns(true);

            var obj =new ProduccionAnimal();
            var result = obj.ValidarDatos(animal);
            Assert.AreEqual(true, result);

        }
        [Test]
        public void TestProduccion2()
        {
            var animal = new Animal();
            var ani = new Mock<IValidarDatosProduccionAnimal>();
            ani.Setup(a => a.ValidarDatos(animal)).Returns(true);

            var obj = new ProduccionAnimal();
            var result = obj.ValidarDatos(animal);
            Assert.AreEqual(false, result);

        }
        [Test]
        public void TestProduccion3()
        {
            var animal = new Animal();
            animal.Id = 100;
            var ani = new Mock<IValidarDatosProduccionAnimal>();
            ani.Setup(a => a.ValidarDatos(animal)).Returns(true);

            var obj = new ProduccionAnimal();
            var result = obj.ValidarDatos(animal);
            Assert.AreEqual(true, result);

        }
        [Test]
        public void TestProduccion4()
        {
            var animal = new Animal();
            animal.Id = 200;
            var ani = new Mock<IValidarDatosProduccionAnimal>();
            ani.Setup(a => a.ValidarDatos(animal)).Returns(true);

            var obj = new ProduccionAnimal();
            var result = obj.ValidarDatos(animal);
            Assert.AreEqual(true, result);

        }
        [Test]
        public void TestProduccion5()
        {
            var anim = new Animal();
            var ani = new Mock<IValidarDatosProduccionAnimal>();
            ani.Setup(a => a.ValidarDatos(anim)).Returns(false);

            var obj = new ProduccionAnimal();
            var result = obj.ValidarDatos(anim);
            Assert.AreEqual(false, result);

        }
    }
}