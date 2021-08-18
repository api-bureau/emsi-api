using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Net.Http;

namespace Emsi.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddEmsi(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmsiSettings>(options => configuration.GetSection(nameof(EmsiSettings)).Bind(options));

            services.AddHttpClient<EmsiClient>()
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(20))
                .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(3) }));


            return services;
        }
    }
}
