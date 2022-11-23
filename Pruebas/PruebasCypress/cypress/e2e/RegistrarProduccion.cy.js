describe('TestProduccion', () => {
    it('RegistrarProduccion', () => {
      let produccion = require('D:/PruebasNode/datos/produccion.json');
      for(let i=0; i<4;i++){
        let numero=parseInt(getRandom(0,4));
        cy.visit(Cypress.env('base_url')+'/RegistrarProduccion')
        cy.get('#IdAnimal').select(numero)
        cy.get('#Fecha').type(produccion.fechas[i])
        cy.get('#Cantidad').type(produccion.litros[i])
        cy.get('#boton').click()
        cy.get('.swal2-title').should('contain', 'Registrado')
      }
    })
  })
  

  function getRandom(min, max) {
    return Math.random() * (max - min) + min;
  }