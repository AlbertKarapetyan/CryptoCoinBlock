namespace CM.Domain.Interfaces
{
    public interface IRepository<TDomainEntity>
    {
        Task<TDomainEntity> CreateAsync(TDomainEntity entity);
        Task<IEnumerable<TDomainEntity>> GetHistoryAsync(short limit, bool isTest);
    }
}
