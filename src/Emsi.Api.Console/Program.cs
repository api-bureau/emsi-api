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
                .UseCommandHandler<VersionsCommand, VersionsCommand.Handler>()
                .UseCommandHandler<SkillsCommand, SkillsCommand.Handler>();
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
        cmd.AddCommand(new VersionsCommand());
        cmd.AddCommand(new SkillsCommand());

        return cmd;
    }
}