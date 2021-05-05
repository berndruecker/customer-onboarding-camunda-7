using System;
using Camunda.Worker;
using Camunda.Worker.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CustomerOnboardingWorker.Handlers;

namespace CustomerOnboardingWorker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddExternalTaskClient()
                .ConfigureHttpClient((provider, client) =>
                {
                    client.BaseAddress = new Uri("http://localhost:8080/engine-rest");
                });

            services.AddCamundaWorker("CustomerOnboardingWorker")
                .AddHandler<CrmSystemEntryHandler>()
                .AddHandler<BillingSystemEntryHandler>();

            services.AddControllers();

            services.AddHealthChecks();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHealthChecks("/health");
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
