describe('TestRegistroGanado', () => {
    it('RegistrarGanado', () => {
      let animales = require('D:/PruebasNode/datos/animales.json');
      for(let i=0; i<4;i++){
        cy.visit(Cypress.env('base_url')+'/RegistrarGanado')
        cy.get('#nombre').type(animales.nombres[i])
        cy.get('#fecha').type(animales.fecha[i])
        cy.get('#sexo').select(animales.sexo[i])
        cy.get('#raza').type(animales.raza[i])
        cy.get('#foto').type(animales.imagen[i])
        cy.get('#boton').click()
        cy.get('.swal2-title').should('contain', 'Registrado')
       
      }
    })
  })
  
  