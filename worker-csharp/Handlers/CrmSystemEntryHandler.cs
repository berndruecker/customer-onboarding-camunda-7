using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Camunda.Worker;

namespace CustomerOnboardingWorker.Handlers
{
    [HandlerTopics("crmEntry", LockDuration = 10000)]
    [HandlerVariables("customer")]
    public class CrmSystemEntryHandler : IExternalTaskHandler
    {
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            externalTask.Variables.TryGetValue("customer", out var usernameVariable);            
            System.Console.WriteLine("Adding customer '" + usernameVariable.Value + "' to CRM system" );
            return new CompleteResult();
        }
    }
}
