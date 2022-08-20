using Microsoft.Extensions.Logging;

namespace Emsi.Api.Console.Services
{
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
            var dto = await _client.Skills.GetStatusAsync();

            if (dto.IsSuccess)
            {
                var status = dto.Data!;

                _logger.LogInformation(status.Healthy.ToString());
                _logger.LogInformation(status.Message);
            }
        }

        public async Task GetMetaAsync()
        {
            var dto = await _client.Skills.GetMetaAsync();

            if (dto.IsSuccess)
            {
                var meta = dto.Data!;

                _logger.LogInformation(meta.Attribution.Title);
                _logger.LogInformation(meta.Attribution.Body);
                _logger.LogInformation($"Latest version: {meta.LatestVersion}");
            }
        }
    }
}
