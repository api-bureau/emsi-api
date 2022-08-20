using Emsi.Api.Console.Services;
using Emsi.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Emsi.Api.Console;

public class Startup
{
    //private IConfigurationRoot Configuration { get; }

    //public Startup()
    //{
    //    var builder = new ConfigurationBuilder()
    //        .AddJsonFile("appsettings.json", true)
    //        .AddUserSecrets<Program>()
    //        .AddEnvironmentVariables();

    //    Configuration = builder.Build();
    //}

    //public void ConfigureServices(IServiceCollection services)
    //{
    //    services.AddLogging(configure =>
    //    {
    //        configure.AddConfiguration(Configuration.GetSection("Logging"));
    //        configure.AddConsole();
    //    });
    //    services.AddEmsi(Configuration);
    //    services.AddScoped<DataService>();
    //}

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddEmsi(context.Configuration);
                services.AddScoped<DataService>();
            });

        return hostBuilder;
    }
}
