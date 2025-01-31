using CM.Application.Contracts;
using CM.DTO;
using MediatR;

namespace CM.Application.Queries
{
    public class GetDogecoinBlocksQuery(bool isTest, short limit) : IGetBlocksQueryContract, IRequest<IEnumerable<DogecoinBlockDto>>
    {
        public bool IsTest { get; set; } = isTest;
        public short Limit { get; set; } = limit;
    }
}
