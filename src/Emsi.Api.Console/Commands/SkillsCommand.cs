using Emsi.Api.Console.Services;
using System.CommandLine;

namespace Emsi.Api.Console.Commands;

public class SkillsCommand : Command
{
    public SkillsCommand(DataService dataService) : base("sample", "Get the top 10 skills")
    {
        SetAction(async (_, _) =>
        {
            await dataService.GetSkillsAsync(10);
        });
    }
}
