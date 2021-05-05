package io.berndruecker.demo.onboarding;

import org.camunda.bpm.engine.delegate.DelegateExecution;
import org.camunda.bpm.engine.delegate.JavaDelegate;
import org.springframework.stereotype.Component;

@Component
public class CrmAdapter implements JavaDelegate  {

    @Override
    public void execute(DelegateExecution context) throws Exception {
        System.out.println("Now we create the customer '" + context.getVariable("customer") + "' in the CRM system");
    }
}
