describe('Login Fundo Santa Elena', () => {
  it('Crear usuario Fundo Santa Elena', () => {
    let data = require('D:/PruebasNode/datos/usuarios.json');
    for(let i=0; i<4;i++){
      cy.visit(Cypress.env('base_url')+"/Usuario/Create")
      cy.log(data.nombres[i])
      cy.log(data.contrasenias[i])
      cy.get('#Nombre').type(data.nombres[i])
      cy.get('#Contrasenia').type(data.contrasenias[i])
      cy.get('#boton').click()
    }
  })
  it('Visit Login', () => {
    let data = require('D:/PruebasNode/datos/usuarios.json');
    for(let i=0; i<4;i++){
      cy.visit(Cypress.env('base_url'))
      cy.log(data.nombres[i])
      cy.log(data.contrasenias[i])
      cy.get('#Nombre').type(data.nombres[i]).should('have.value',data.nombres[i])//ID
      cy.get('#Contrasenia').type(data.contrasenias[i]).should('have.value',data.contrasenias[i])//abriendo con el ID
      cy.get('.btn-block').click()
    }
  })
})






