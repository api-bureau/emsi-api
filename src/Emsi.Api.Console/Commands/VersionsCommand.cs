using Emsi.Api.Console.Services;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Emsi.Api.Console.Commands;

public class VersionsCommand : Command
{
    public VersionsCommand() : base("versions", "- get skill versions") { }

    public new class Handler : ICommandHandler
    {
        private readonly DataService _dataService;

        public Handler(DataService dataService) => _dataService = dataService;

        public int Invoke(InvocationContext context) => throw new NotImplementedException();

        public async Task<int> InvokeAsync(InvocationContext context)
        {
            await _dataService.GetVersionsAsync();

            return 0;
        }
    }
}