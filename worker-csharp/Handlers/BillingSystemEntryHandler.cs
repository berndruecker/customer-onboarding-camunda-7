using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Camunda.Worker;

namespace CustomerOnboardingWorker.Handlers
{
    [HandlerTopics("billingEntry")]
    [HandlerVariables("customer")]
    public class BillingSystemEntryHandler : IExternalTaskHandler
    {
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            externalTask.Variables.TryGetValue("customer", out var usernameVariable);            
            System.Console.WriteLine("Adding customer '" + usernameVariable.Value + "' to billing system" );
            return new CompleteResult();
        }
    }
}
