using CM.Application.Contracts;
using CM.DTO;
using MediatR;

namespace CM.Application.Queries
{
    public class GetLitecoinBlocksQuery(bool isTest, short limit) : IGetBlocksQueryContract, IRequest<IEnumerable<LitecoinBlockDto>>
    {
        public bool IsTest { get; set; } = isTest;
        public short Limit { get; set; } = limit;
    }
}
