using Emsi.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddEmsi(Configuration);

            services.AddScoped<DataService>();
        }
    }
}
