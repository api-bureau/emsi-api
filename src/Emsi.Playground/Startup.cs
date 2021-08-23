using Emsi.Api.Extensions;
using Emsi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            services.AddLogging(configure =>
            {
                configure.AddConfiguration(Configuration.GetSection("Logging"));
                configure.AddConsole();
            });

            services.AddDbContext<EmsiContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddEmsi(Configuration);
            services.AddScoped<DataService>();
        }
    }
}
