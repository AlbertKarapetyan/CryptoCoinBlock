using CM.Application.Contracts;
using CM.Domain.Entities;
using CM.Domain.Services;
using CM.DTO;
using MediatR;

namespace CM.Application.Handlers
{
    internal class GenericImportBlockCommandHandler<TRequest, TResponse, TModel> : IRequestHandler<TRequest, TResponse?>
        where TRequest : IRequest<TResponse>
        where TResponse : BaseCoinBlockDto
        where TModel : BaseCoinBlock
    {
        private readonly ICoinBlockService<TModel, TResponse> _coinBlockService;

        public GenericImportBlockCommandHandler(ICoinBlockService<TModel, TResponse> coinBlockService)
        {
            _coinBlockService = coinBlockService;
        }

        public async Task<TResponse?> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (request is IImportCoinBlockCommandContract command)
            {
                return await _coinBlockService.ImportAsync(command.IsTest);
            }

            throw new InvalidOperationException("The request does not implement IImportCoinBlockCommandContract.");
        }
    }
}
