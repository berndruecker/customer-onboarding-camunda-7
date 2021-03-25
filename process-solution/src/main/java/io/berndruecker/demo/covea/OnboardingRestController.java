package io.berndruecker.demo.covea;

import org.camunda.bpm.engine.ProcessEngine;
import org.glassfish.jersey.internal.guava.Maps;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

import static org.springframework.web.bind.annotation.RequestMethod.PUT;

import javax.inject.Inject;
import javax.servlet.http.HttpServletResponse;
import java.util.Collections;
import java.util.UUID;

@RestController
public class OnboardingRestController {

    @Inject
    private ProcessEngine camunda;

    @RequestMapping(path = "/customer", method = PUT)
    public String kickOffCustomerOnboarding(@RequestParam String name, HttpServletResponse response) throws Exception {

        String traceId = UUID.randomUUID().toString();
        System.out.println("PUT payment received for customer '" + name + "'");

        camunda.getRuntimeService().startProcessInstanceByKey(
                "onboarding", // process definition key
                traceId, // business key to set for the instance
                Collections.singletonMap("customer", name)); // process variables

        return "{\"status\":\"completed\", \"traceId\": \"" + traceId + "\"}";
    }
}