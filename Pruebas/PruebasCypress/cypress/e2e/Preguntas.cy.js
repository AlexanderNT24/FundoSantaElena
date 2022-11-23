describe('TestPreguntas', () => {
    it('RegistrarVenta', () => {
      let preguntas = require('D:/PruebasNode/datos/preguntas.json');
      cy.visit(Cypress.env('base_url')+'/ChatBot')
      for(let i=0; i<6;i++){  
        cy.get('#Mensaje').type(preguntas.pregunta[i])
        cy.get('#boton').click()
        cy.log(preguntas.respuesta[i])
        cy.get('.msg_cotainer').should('contain', preguntas.respuesta[i])
        
        
      }
    })
})