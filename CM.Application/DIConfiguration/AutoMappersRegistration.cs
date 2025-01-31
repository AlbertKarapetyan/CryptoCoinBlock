using CM.Domain.Mappers;
using CM.Infrastructure.Mappings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CM.Application.DIConfiguration
{
    public static class AutoMappersRegistration
    {
        public static void AddAutoMappers(this IServiceCollection services, ILogger logger)
        {
            logger.LogInformation($"Registering AutoMappers");
            
            services.AddAutoMapper(typeof(CoinBlocksMappingProfile).Assembly);
            services.AddAutoMapper(typeof(DBMappingProfile).Assembly);
        }
    }
}
