namespace CM.Domain.Services
{
    public interface ICreateAllBlocksService
    {
        Task<IEnumerable<object>> ImportAsync(bool IsTest);
    }
}
