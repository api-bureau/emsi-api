using Emsi.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Net.Http;

namespace Emsi.Playground
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<EmsiSettings>(Configuration.GetSection(nameof(EmsiSettings)));

            //services.AddEmsi();

            services.Configure<EmsiSettings>(options => Configuration.GetSection(nameof(EmsiSettings)).Bind(options));

            services.AddHttpClient<EmsiClient>()
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(20))
                .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(3) }));

            services.AddScoped<DataService>();
        }
    }
}
