using CM.Domain.Entities;
using CM.Domain.Services;
using CM.DTO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CM.Application.DIConfiguration
{
    public static class DIServicesRegistration
    {
        public static void AddServices(this IServiceCollection services, ILogger logger)
        {
            logger.LogInformation($"Registering Domain entities");

            services.AddScoped<BitcoinBlock>();
            services.AddScoped<LitecoinBlock>();
            services.AddScoped<EthcoinBlock>();
            services.AddScoped<DashcoinBlock>();
            services.AddScoped<DogecoinBlock>();
            services.AddScoped<CypherBlock>();

            logger.LogInformation($"Configuring Generic ICoinBlockService");

            services.AddScoped<ICoinBlockService<BitcoinBlock, BitcoinBlockDto>, CoinBlockService<BitcoinBlock, BitcoinBlockDto>>();
            services.AddScoped<ICoinBlockService<LitecoinBlock, LitecoinBlockDto>, CoinBlockService<LitecoinBlock, LitecoinBlockDto>>();
            services.AddScoped<ICoinBlockService<EthcoinBlock, EthcoinBlockDto>, CoinBlockService<EthcoinBlock, EthcoinBlockDto>>();
            services.AddScoped<ICoinBlockService<DashcoinBlock, DashcoinBlockDto>, CoinBlockService<DashcoinBlock, DashcoinBlockDto>>();
            services.AddScoped<ICoinBlockService<DogecoinBlock, DogecoinBlockDto>, CoinBlockService<DogecoinBlock, DogecoinBlockDto>>();
            services.AddScoped<ICoinBlockService<CypherBlock, CypherBlockDto>, CoinBlockService<CypherBlock, CypherBlockDto>>();

            logger.LogInformation($"Configuring ICreateAllBlocksService");

            services.AddScoped<ICreateAllBlocksService, CreateAllBlocksService>();

        }
    }
}
