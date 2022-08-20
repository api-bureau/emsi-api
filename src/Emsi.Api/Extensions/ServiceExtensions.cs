using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Emsi.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddEmsi(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LightcastSettings>(options => configuration.GetSection(nameof(LightcastSettings)).Bind(options));

        services.AddHttpClient<EmsiClient>()
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(20))
            .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(3) }));


        return services;
    }
}
