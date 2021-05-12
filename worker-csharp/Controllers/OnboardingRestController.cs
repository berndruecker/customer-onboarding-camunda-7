using CamundaClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CustomerOnboardingWorker.Controllers
{
    [ApiController]
    public class OnboardingRestController : ControllerBase
    {
        [HttpGet] // Should be PUT but had trouble and too limited time to get it to work with DotNet 3
        [Route("/customer")]
        public ActionResult PutCustomer([FromQuery]String name)
        {
            System.Console.WriteLine("Starting onboarding process for '" + name + "'" );

            var camunda = new CamundaEngineClient(new Uri("http://localhost:8080/engine-rest/engine/default/"), null, null);

            var traceId = Guid.NewGuid().ToString();
            var result = new Dictionary<String, String>();

            string processInstanceId = camunda.BpmnWorkflowService.StartProcessInstance(
                "onboarding",
                traceId,
                new Dictionary<string, object>()
                {
                    {"customer", name }
                });

            result.Add("traceId", traceId);
            return Ok(result);
        }
    }
}