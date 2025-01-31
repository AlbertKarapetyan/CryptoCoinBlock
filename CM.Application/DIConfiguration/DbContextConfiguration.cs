using CM.Domain.Entities;
using CM.Domain.Interfaces;
using CM.Infrastructure.Data;
using CM.Infrastructure.Data.Interfaces;
using CM.Infrastructure.Data.Models;
using CM.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CM.Application.DIConfiguration
{
    public static class DbContextConfiguration
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration, ILogger logger)
        {
            // Check if DBProvider is null or empty
            if (string.IsNullOrEmpty(configuration["DBProvider"]))
            {
                logger.LogError("DBProvider is required in the configuration.");
                throw new ArgumentException("DBProvider is required in the configuration.");
            }

            logger.LogInformation($"Configuring database provider: {configuration["DBProvider"]}");

            // Checking ConnectionString
            var connectionString = configuration.GetConnectionString(configuration["DBProvider"]!);
            if (string.IsNullOrEmpty(connectionString))
            {
                logger.LogError($"ConnectionString is required for the provider: {configuration["DBProvider"]}");
                throw new ArgumentException($"ConnectionString is required for the provider: {configuration["DBProvider"]}");
            }

            switch (configuration["DBProvider"])
            {
                case "PGSql":
                    {
                        // Configure PostgreSQL database
                        logger.LogInformation("Configuring PostgreSQL database.");

                        services.AddDbContext<ApplicationDbContext>(
                        options => options.UseNpgsql(
                            connectionString,
                            x => x.MigrationsAssembly("CM.Data.Migrations")
                        ));

                        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

                        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

                        break;
                    }
                case "MSSql":
                    {
                        // Configure SQL Server database
                        logger.LogInformation("Configuring SQL Server database.");

                        services.AddDbContext<ApplicationDbContext>(
                        options => options.UseSqlServer(
                            connectionString,
                            x => x.MigrationsAssembly("CM.Data.Migrations")
                        ).EnableSensitiveDataLogging()
                        .EnableDetailedErrors());

                        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

                        break;
                    }
                default:
                    {
                        // Log and throw exception for unsupported providers
                        logger.LogError($"Unsupported database provider: {configuration["DBProvider"]}");
                        throw new Exception($"Unsupported provider: {configuration["DBProvider"]}");
                    }
            }

            // Register generic repository
            services.AddScoped<IRepository<EthcoinBlock>, Repository<EthcoinBlockModel, EthcoinBlock>>();
            services.AddScoped<IRepository<BitcoinBlock>, Repository<BitcoinBlockModel, BitcoinBlock>>();
            services.AddScoped<IRepository<LitecoinBlock>, Repository<LitecoinBlockModel, LitecoinBlock>>();
            services.AddScoped<IRepository<DashcoinBlock>, Repository<DashcoinBlockModel, DashcoinBlock>>();
            services.AddScoped<IRepository<DogecoinBlock>, Repository<DogecoinBlockModel, DogecoinBlock>>();
            services.AddScoped<IRepository<CypherBlock>, Repository<CypherBlockModel, CypherBlock>>();

            logger.LogInformation("Generic IRepository<> registered.");
        }
    }
}
