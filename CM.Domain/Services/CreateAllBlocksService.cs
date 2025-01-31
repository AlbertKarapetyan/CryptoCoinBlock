using CM.Domain.Entities;
using CM.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CM.Domain.Services
{
    public class CreateAllBlocksService: ICreateAllBlocksService
    {
        private readonly ICoinBlockService<BitcoinBlock, BitcoinBlockDto> _btcBService;
        private readonly ICoinBlockService<LitecoinBlock, LitecoinBlockDto> _ltcBService;
        private readonly ICoinBlockService<DashcoinBlock, DashcoinBlockDto> _dashBService;
        private readonly ICoinBlockService<DogecoinBlock, DogecoinBlockDto> _dogeBService;
        private readonly ICoinBlockService<EthcoinBlock, EthcoinBlockDto> _ethBService;
        private readonly ICoinBlockService<CypherBlock, CypherBlockDto> _cypherBService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CreateAllBlocksService> _logger;

        public CreateAllBlocksService(
            ICoinBlockService<BitcoinBlock, BitcoinBlockDto> btcBService,
            ICoinBlockService<LitecoinBlock, LitecoinBlockDto> ltcBService,
            ICoinBlockService<DashcoinBlock, DashcoinBlockDto> dashBService,
            ICoinBlockService<DogecoinBlock, DogecoinBlockDto> dogeBService,
            ICoinBlockService<EthcoinBlock, EthcoinBlockDto> ethBService,
            ICoinBlockService<CypherBlock, CypherBlockDto> cypherBService,
            IConfiguration configuration,
            ILogger<CreateAllBlocksService> logger)
        {
            _btcBService = btcBService;
            _ltcBService = ltcBService;
            _dashBService = dashBService;
            _dogeBService = dogeBService;
            _ethBService = ethBService;
            _cypherBService = cypherBService;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IEnumerable<object>> ImportAsync(bool IsTest)
        {
            var result = new List<object>();
            var semaphore = new SemaphoreSlim(1);
            var delayBetweenRequests = TimeSpan.FromMilliseconds(Convert.ToDouble(_configuration["RequestRateLimit"]));

            try
            {
                _logger.LogInformation("Starting import of all crypto blocks for supported currencies");

                var services = new List<Func<Task<object?>>>
                {
                    () => _btcBService.ImportAsync(IsTest, true).ContinueWith(task => (object?)task.Result),
                    () => _ltcBService.ImportAsync(IsTest, true).ContinueWith(task => (object?)task.Result),
                    () => _dashBService.ImportAsync(IsTest, true).ContinueWith(task => (object?)task.Result),
                    () => _dogeBService.ImportAsync(IsTest, true).ContinueWith(task => (object?)task.Result),
                    () => _ethBService.ImportAsync(IsTest, true).ContinueWith(task => (object?)task.Result),
                    () => _cypherBService.ImportAsync(IsTest, true).ContinueWith(task => (object?)task.Result)
                };

                var tasks = services.Select(async service =>
                {
                    await semaphore.WaitAsync();
                    try
                    {
                        var importResult = await service();
                        if (importResult != null)
                        {
                            result.Add(importResult);
                        }
                    }
                    finally
                    {
                        semaphore.Release();
                    }

                    await Task.Delay(delayBetweenRequests);
                });

                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }

            return result;
        }

    }
}
