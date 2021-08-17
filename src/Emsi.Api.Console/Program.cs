using Emsi.Api.Console;
using Emsi.Api.Console.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

public class Program
{
    private static DataService _dataService = default!;

    public static async Task<int> Main(string[] args)
    {
        var services = new ServiceCollection();

        var startup = new Startup();

        startup.ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        _dataService = serviceProvider.GetService<DataService>()
            ?? throw new ArgumentNullException($"{nameof(DataService)} cannot be null");

        var cmd = GetRootCommand();

        return await cmd.InvokeAsync(args);
    }

    private static RootCommand GetRootCommand()
    {
        var cmd = new RootCommand("Emsi.API console application to fetch Emsi API.");

        //cmd.AddCommand(new Command("test", "- test sync")
        //{
        //    Handler = CommandHandler.Create(async () =>
        //    {
        //        await _synchroniseService.SynchroniseTestAsync();
        //    })
        //});

        cmd.AddCommand(SkillsCommand());

        return cmd;
    }

    private static Command SkillsCommand()
    {
        var cmd = new Command("skills", "- get Skills");

        cmd.AddCommand(new Command("status", "- get API status")
        {
            Handler = CommandHandler.Create(async () => await _dataService.GetStatusAsync())
        });

        cmd.AddCommand(new Command("meta", "- get API meta"));

        return cmd;
    }
}

