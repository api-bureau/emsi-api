using Emsi.Api.Console.Commands;
using Emsi.Api.Console.Services;
using Emsi.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        var parser = BuildCommandLine()
            .UseHost(_ => Host.CreateDefaultBuilder(args), (builder) =>
            {
                builder.ConfigureServices((context, services) =>
                {
                    services.AddEmsi(context.Configuration);
                    services.AddTransient<DataService>();
                })
                .UseCommandHandler<StatusCommand, StatusCommand.Handler>()
                .UseCommandHandler<MetaCommand, MetaCommand.Handler>()
                .UseCommandHandler<VersionCommand, VersionCommand.Handler>();
            })
            .UseDefaults().Build();

        return await parser.InvokeAsync(args);
    }

    private static CommandLineBuilder BuildCommandLine()
    {
        var root = new RootCommand("Lightcast.API console application to fetch Lightcast API.");

        root.AddCommand(SkillsCommand());

        return new CommandLineBuilder(root);
    }

    private static Command SkillsCommand()
    {
        var cmd = new Command("skills", "- get Skills");

        cmd.AddCommand(new StatusCommand());
        cmd.AddCommand(new MetaCommand());
        cmd.AddCommand(new VersionCommand());

        //var versionCommand = new Command("versions", "- get skill versions");
        //versionCommand.SetHandler(async () => await _dataService.GetVersionsAsync());
        //cmd.AddCommand(versionCommand);

        //var sampleCommand = new Command("sample", "- get top 10 skills");
        //sampleCommand.SetHandler(async () => await _dataService.GetSkillsAsync(10));
        //cmd.AddCommand(sampleCommand);

        return cmd;
    }
}