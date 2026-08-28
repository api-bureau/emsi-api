using Emsi.Api.Console.Services;
using System.CommandLine;

namespace Emsi.Api.Console.Commands;

public class StatusCommand : Command
{
    public StatusCommand(DataService dataService) : base("status", "Get API status")
    {
        SetAction(async (_, _) =>
        {
            await dataService.GetStatusAsync();
        });
    }
}
