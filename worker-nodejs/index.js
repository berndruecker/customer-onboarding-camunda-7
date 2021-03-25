const { Client, Variables } = require("camunda-external-task-client-js");

const config = { baseUrl: "http://localhost:8080/engine-rest", interval: 50, asyncResponseTimeout: 10000};
const client = new Client(config);

client.subscribe("simRegistration", async function({ task, taskService }) {
  console.log('SIM registered for [%s]', task.variables.get("customer"));
  await taskService.complete(task);
});
