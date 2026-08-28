using Emsi.Api.Console.Services;
using System.CommandLine;

namespace Emsi.Api.Console.Commands;

public class VersionsCommand : Command
{
    public VersionsCommand(DataService dataService) : base("versions", "Get skill versions")
    {
        SetAction(async (_, _) =>
        {
            await dataService.GetVersionsAsync();
        });
    }
}
