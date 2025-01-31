using CM.Application.Contracts;
using CM.DTO;
using MediatR;

namespace CM.Application.Queries
{
    public class GetBitcoinBlocksQuery(bool isTest, short limit) : IGetBlocksQueryContract, IRequest<IEnumerable<BitcoinBlockDto>>
    {
        public bool IsTest { get; set; } = isTest;
        public short Limit { get; set; } = limit;
    }
}
