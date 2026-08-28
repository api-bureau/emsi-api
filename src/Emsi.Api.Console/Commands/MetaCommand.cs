using Emsi.Api.Console.Services;
using System.CommandLine;

namespace Emsi.Api.Console.Commands;

public class MetaCommand : Command
{
    public MetaCommand(DataService dataService) : base("meta", "Get API metadata")
    {
        SetAction(async (_, _) =>
        {
            await dataService.GetMetaAsync();
        });
    }
}
