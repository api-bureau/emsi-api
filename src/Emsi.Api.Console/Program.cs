using Emsi.Api.Console.Commands;
using Emsi.Api.Console.Services;
using Emsi.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddEmsi(builder.Configuration);
        builder.Services.AddTransient<DataService>();

        using var host = builder.Build();
        var rootCommand = BuildCommandLine(host.Services.GetRequiredService<DataService>());

        return await rootCommand.Parse(args).InvokeAsync();
    }

    private static RootCommand BuildCommandLine(DataService dataService)
    {
        var root = new RootCommand("Lightcast.API console application to fetch Lightcast API.");

        var skills = new Command("skills", "Get skills API information");
        skills.Subcommands.Add(new StatusCommand(dataService));
        skills.Subcommands.Add(new MetaCommand(dataService));
        skills.Subcommands.Add(new VersionsCommand(dataService));
        skills.Subcommands.Add(new SkillsCommand(dataService));
        root.Subcommands.Add(skills);

        return root;
    }
}
