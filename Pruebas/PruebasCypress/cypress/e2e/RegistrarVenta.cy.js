  
  describe('TestVenta', () => {
    it('RegistrarVenta', () => {
      let venta = require('D:/PruebasNode/datos/venta.json');
      for(let i=0; i<4;i++){
        cy.visit(Cypress.env('base_url')+'/RegistrarVenta')
        cy.get('#Fecha').type(venta.fechas[i])
        cy.get('#Destino').select(venta.destinos[i])
        cy.get('#Cantidad').clear().type(venta.litros[i])
        cy.get('#Precio').type(venta.costos[i])
        cy.get('#boton').click()
        cy.get('.swal2-title').should('contain', 'Registrado')
      }
    })
  })
  
  function getRandom(min, max) {
    return Math.random() * (max - min) + min;
  }