using CM.Application.Commands;
using CM.Domain.Services;
using MediatR;

namespace CM.Application.Handlers
{
    internal class ImportAllBlocksCommandHandler : IRequestHandler<ImportAllBlocksCommand, IEnumerable<object>>
    {
        private readonly ICreateAllBlocksService _createAllBlocksService;

        public ImportAllBlocksCommandHandler(ICreateAllBlocksService createAllBlocksService)
        {
            _createAllBlocksService = createAllBlocksService;
        }

        public async Task<IEnumerable<object>> Handle(ImportAllBlocksCommand request, CancellationToken cancellationToken)
        {
            return await _createAllBlocksService.ImportAsync(request.IsTest);
        }
    }
}
