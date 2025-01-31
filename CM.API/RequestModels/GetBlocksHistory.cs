using CM.Application.Contracts;

namespace CM.API.RequestModels
{
    public class GetBlocksHistory : IGetBlocksQueryContract
    {
        public bool IsTest { get; set; }
        public short Limit { get; set; }
    }
}
