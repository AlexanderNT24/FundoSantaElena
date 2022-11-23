const { defineConfig } = require("cypress");

module.exports = defineConfig({
  env:{
        base_url:'https://localhost:7214'
  },
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
});
