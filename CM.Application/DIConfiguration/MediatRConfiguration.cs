using CM.Application.Commands;
using CM.Application.Handlers;
using CM.Application.Queries;
using CM.Domain.Entities;
using CM.DTO;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CM.Application.DIConfiguration
{
    public static class MediatRConfiguration
    {
        public static void AddMediatr(this IServiceCollection services, ILogger logger)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            
            logger.LogInformation("Generic Command Handler registering...");
            
            services.AddScoped(
                typeof(IRequestHandler<ImportBitcoinBlockCommand, BitcoinBlockDto>), 
                typeof(GenericImportBlockCommandHandler<ImportBitcoinBlockCommand, BitcoinBlockDto, BitcoinBlock>)
            );

            services.AddScoped(
                typeof(IRequestHandler<ImportLitecoinBlockCommand, LitecoinBlockDto>),
                typeof(GenericImportBlockCommandHandler<ImportLitecoinBlockCommand, LitecoinBlockDto, LitecoinBlock>)
            );

            services.AddScoped(
                typeof(IRequestHandler<ImportDashcoinBlockCommand, DashcoinBlockDto>),
                typeof(GenericImportBlockCommandHandler<ImportDashcoinBlockCommand, DashcoinBlockDto, DashcoinBlock>)
            );

            services.AddScoped(
                typeof(IRequestHandler<ImportDogecoinBlockCommand, DogecoinBlockDto>),
                typeof(GenericImportBlockCommandHandler<ImportDogecoinBlockCommand, DogecoinBlockDto, DogecoinBlock>)
            );

            services.AddScoped(
                typeof(IRequestHandler<ImportEthcoinBlockCommand, EthcoinBlockDto>),
                typeof(GenericImportBlockCommandHandler<ImportEthcoinBlockCommand, EthcoinBlockDto, EthcoinBlock>)
            );

            services.AddScoped(
                typeof(IRequestHandler<ImportCypherBlockCommand, CypherBlockDto>),
                typeof(GenericImportBlockCommandHandler<ImportCypherBlockCommand, CypherBlockDto, CypherBlock>)
            );

            logger.LogInformation("Generic Query Handler registering...");

            services.AddScoped(
                typeof(IRequestHandler<GetBitcoinBlocksQuery, IEnumerable<BitcoinBlockDto>>),
                typeof(GenericGetBlocksQueryHandler<GetBitcoinBlocksQuery, BitcoinBlockDto, BitcoinBlock>)
            );

            services.AddScoped(
                typeof(IRequestHandler<GetLitecoinBlocksQuery, IEnumerable<LitecoinBlockDto>>),
                typeof(GenericGetBlocksQueryHandler<GetLitecoinBlocksQuery, LitecoinBlockDto, LitecoinBlock>)
            );

            services.AddScoped(
                typeof(IRequestHandler<GetDashcoinBlocksQuery, IEnumerable<DashcoinBlockDto>>),
                typeof(GenericGetBlocksQueryHandler<GetDashcoinBlocksQuery, DashcoinBlockDto, DashcoinBlock>)
            );

            services.AddScoped(
                typeof(IRequestHandler<GetDogecoinBlocksQuery, IEnumerable<DogecoinBlockDto>>),
                typeof(GenericGetBlocksQueryHandler<GetDogecoinBlocksQuery, DogecoinBlockDto, DogecoinBlock>)
            );

            services.AddScoped(
                typeof(IRequestHandler<GetEthcoinBlocksQuery, IEnumerable<EthcoinBlockDto>>),
                typeof(GenericGetBlocksQueryHandler<GetEthcoinBlocksQuery, EthcoinBlockDto, EthcoinBlock>)
            );

            services.AddScoped(
                typeof(IRequestHandler<GetCypherBlocksQuery, IEnumerable<CypherBlockDto>>),
                typeof(GenericGetBlocksQueryHandler<GetCypherBlocksQuery, CypherBlockDto, CypherBlock>)
            );
        }
    }
}
