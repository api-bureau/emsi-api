using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Emsi.Api.Console.Services;

public class DataService
{
    private readonly EmsiClient _client;
    private readonly ILogger<DataService> _logger;

    public DataService(EmsiClient client, ILogger<DataService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task GetStatusAsync()
    {
        var response = await _client.Skills.GetStatusAsync();

        if (response.IsSuccess)
        {
            var status = response.Data!;

            _logger.LogInformation(status.Healthy.ToString());
            _logger.LogInformation(status.Message);
        }
    }

    public async Task GetMetaAsync()
    {
        var response = await _client.Skills.GetMetaAsync();

        if (response.IsSuccess)
        {
            var meta = response.Data!;

            _logger.LogInformation(meta.Attribution.Title);
            _logger.LogInformation(meta.Attribution.Body);
            _logger.LogInformation($"Latest version: {meta.LatestVersion}");
        }
    }

    public async Task GetVersionsAsync()
    {
        var response = await _client.Skills.GetVersionsAsync();

        if (response.IsSuccess)
        {
            var items = response.Data!;

            _logger.LogInformation("Versions: {0}", items.Count);

            if (items.Count > 0)
            {
                _logger.LogInformation("Sample: {0}", items[0]);
            }
        }
    }

    public async Task GetSkillsAsync(int count)
    {
        var response = await _client.Skills.GetAsync("latest", count);

        if (response.IsSuccess)
        {
            var items = response.Data!;

            _logger.LogInformation("Items: {0}", items.Count);

            if (items.Count > 0)
            {
                _logger.LogInformation("Sample: {0}", JsonSerializer.Serialize(items));
            }
        }
    }
}
