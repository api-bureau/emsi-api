using Emsi.Api.Console.Services;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace Emsi.Api.Console
{
    public class Program
    {
        private static DataService _dataService = default!;

        public static async Task<int> Main(string[] args)
        {
            var services = new ServiceCollection();

            var startup = new Startup();

            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            _dataService = serviceProvider.GetService<DataService>();

            var cmd = GetRootCommand();

            return await cmd.InvokeAsync(args);
        }

        private static RootCommand GetRootCommand()
        {
            var cmd = new RootCommand("Emsi.API console application to fetch Emsi API.");

            cmd.AddCommand(SkillsCommand());

            return cmd;
        }

        private static Command SkillsCommand()
        {
            var cmd = new Command("skills", "- get Skills");

            cmd.AddCommand(new Command("status", "- get API status")
            {
                Handler = CommandHandler.Create(async() => await _dataService.GetStatusAsync())
            });

            cmd.AddCommand(new Command("meta", "- get API meta"));

            return cmd;
        }
    }
}
