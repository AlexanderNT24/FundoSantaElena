//npx cypress open

describe('Login Fundo Santa Elena', () => {
  it('Crear usuario Fundo Santa Elena', () => {
    let data = require('D:/PruebasNode/datos/usuarios.json');
    for(let i=0; i<4;i++){
      cy.visit('https://localhost:7214/Usuario/Create')
      cy.log(data.nombres[i])
      cy.log(data.contrasenias[i])
      cy.get('#nombre').type(data.nombres[i])
      cy.get('#contrasenia').type(data.contrasenias[i])
      cy.get('#boton').click()
    }
  })
  it('Visit Login', () => {
    let data = require('D:/PruebasNode/datos/usuarios.json');
    for(let i=0; i<4;i++){
      cy.visit('https://localhost:7214')
      cy.log(data.nombres[i])
      cy.log(data.contrasenias[i])
      cy.get('#Nombre').type(data.nombres[i]).should('have.value',data.nombres[i])//ID
      cy.get('#Contrasenia').type(data.contrasenias[i]).should('have.value',data.contrasenias[i])//abriendo con el ID
      cy.get('.btn-block').click()
    }
  })
})


describe('TestRegistroGanado', () => {
  it('RegistrarGanado', () => {
    let animales = require('D:/PruebasNode/datos/animales.json');
    for(let i=0; i<4;i++){
      cy.visit('https://localhost:7214/RegistrarGanado')
      cy.get('#nombre').type(animales.nombres[i])
      cy.get('#fecha').type(animales.fecha[i])
      cy.get('#sexo').type(animales.sexo[i])
      cy.get('#raza').type(animales.raza[i])
      cy.get('#foto').type(animales.imagen[i])
      cy.get('#boton').click()
    }
  })
})


describe('TestEstadoGanado', () => {
  it('RegistrarSalud', () => {
    let estados = require('D:/PruebasNode/datos/estadoGanado.json');
    for(let i=0; i<4;i++){
      cy.visit('https://localhost:7214/RegistrarEstadoGanado')
      cy.get('#animal').type(estados.nombres[i])
      cy.get('#estado').type(estados.estados[i])
      cy.get('#fecha').type(estados.fechas[i])
      cy.get('#boton').click()
    }
  })
})

describe('TestCicloFertilidad', () => {
  it('RegistrarFertilidad', () => {
    let fertilizaciones = require('D:/PruebasNode/datos/fertilizacion.json');
    for(let i=0; i<4;i++){
      cy.visit('https://localhost:7214/RegistrarCicloFertilidad')
      cy.get('#IdAnimal').type(fertilizaciones.nombres[i])
      cy.get('#Detalles').type(fertilizaciones.metodos[i])
      cy.get('#Fecha').type(fertilizaciones.fechas[i])
      cy.get('#boton').click()
    }
  })
})

describe('TestProduccion', () => {
  it('RegistrarProduccion', () => {
    let produccion = require('D:/PruebasNode/datos/produccion.json');
    for(let i=0; i<4;i++){
      cy.visit('https://localhost:7214/RegistrarProduccion')
      cy.get('#IdAnimal').type(produccion.nombres[i])
      cy.get('#Fecha').type(produccion.fechas[i])
      cy.get('#Cantidad').type(produccion.litros[i])
      cy.get('#boton').click()
    }
  })
})


describe('TestVenta', () => {
  it('RegistrarVenta', () => {
    let venta = require('D:/PruebasNode/datos/venta.json');
    for(let i=0; i<4;i++){
      cy.visit('https://localhost:7214/RegistrarVenta')
      cy.get('#Fecha').type(venta.fechas[i])
      cy.get('#Destino').type(venta.destinos[i])
      cy.get('#Cantidad').clear().type(venta.litros[i])
      cy.get('#Precio').type(venta.costos[i])
      cy.get('#boton').click()
    }
  })
})