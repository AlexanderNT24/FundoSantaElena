describe('TestCicloFertilidad', () => {
    it('RegistrarFertilidad', () => {
      let fertilizaciones = require('D:/PruebasNode/datos/fertilizacion.json');
      for(let i=0; i<4;i++){
        let numero=parseInt(getRandom(0,4));
        cy.visit(Cypress.env('base_url')+'/RegistrarCicloFertilidad')
        cy.get('#IdAnimal').select(numero)
        cy.get('#Detalles').select(fertilizaciones.metodos[i])
        cy.get('#Fecha').type(fertilizaciones.fechas[i])
        cy.get('#boton').click()
        cy.get('.swal2-title').should('contain', 'Registrado')
      }
    })
  })
  
  
  function getRandom(min, max) {
    return Math.random() * (max - min) + min;
  }