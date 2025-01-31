using CM.Application.Contracts;
using CM.DTO;
using MediatR;

namespace CM.Application.Queries
{
    public class GetEthcoinBlocksQuery(bool isTest, short limit) : IGetBlocksQueryContract, IRequest<IEnumerable<EthcoinBlockDto>>
    {
        public bool IsTest { get; set; } = isTest;
        public short Limit { get; set; } = limit;
    }
}
