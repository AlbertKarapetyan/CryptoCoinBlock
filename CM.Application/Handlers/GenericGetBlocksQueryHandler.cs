using CM.Application.Contracts;
using CM.Domain.Entities;
using CM.Domain.Services;
using CM.DTO;
using MediatR;

namespace CM.Application.Handlers
{
    internal class GenericGetBlocksQueryHandler<TRequest, TResponse, TModel> : IRequestHandler<TRequest, IEnumerable<TResponse>>
        where TRequest : IRequest<IEnumerable<TResponse>>
        where TResponse : BaseCoinBlockDto
        where TModel : BaseCoinBlock
    {
        private readonly ICoinBlockService<TModel, TResponse> _coinBlockService;

        public GenericGetBlocksQueryHandler(ICoinBlockService<TModel, TResponse> coinBlockService)
        {
            _coinBlockService = coinBlockService;
        }

        public async Task<IEnumerable<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (request is IGetBlocksQueryContract query)
            {
                return await _coinBlockService.GetHistoryAsync(query.Limit, query.IsTest);
            }

            throw new InvalidOperationException("The request does not implement IGetBlocksQueryContract.");
        }
    }
}
