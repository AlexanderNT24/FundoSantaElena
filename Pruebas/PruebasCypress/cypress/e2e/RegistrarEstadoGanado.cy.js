describe('TestEstadoGanado', () => {
    it('RegistrarSalud', () => {
      let estados = require('D:/PruebasNode/datos/estadoGanado.json');
      for(let i=0; i<4;i++){
        let numero=parseInt(getRandom(0,4));
        cy.visit(Cypress.env('base_url')+'/RegistrarEstadoGanado')
        cy.get('#animal').select(numero)
        cy.get('#estado').select(estados.estados[i])
        cy.get('#fecha').type(estados.fechas[i])
        cy.get('#boton').click()
        cy.get('.swal2-title').should('contain', 'Registrado')
      }
    })
  })
  
  function getRandom(min, max) {
    return Math.random() * (max - min) + min;
  }