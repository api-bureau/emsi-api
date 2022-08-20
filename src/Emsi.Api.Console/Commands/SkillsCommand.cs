using Emsi.Api.Console.Services;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Emsi.Api.Console.Commands;

public class SkillsCommand : Command
{
    public SkillsCommand() : base("sample", "- get top 10 skills") { }

    public new class Handler : ICommandHandler
    {
        private readonly DataService _dataService;

        public Handler(DataService dataService) => _dataService = dataService;

        public int Invoke(InvocationContext context) => throw new NotImplementedException();

        public async Task<int> InvokeAsync(InvocationContext context)
        {
            await _dataService.GetSkillsAsync(10);

            return 0;
        }
    }
}