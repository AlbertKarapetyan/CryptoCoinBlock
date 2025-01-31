namespace CM.Application.Contracts
{
    public interface IGetBlocksQueryContract
    {
        short Limit { get; set; }
        bool IsTest { get; set; }
    }
}
