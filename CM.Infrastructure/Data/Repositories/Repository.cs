using AutoMapper;
using CM.Domain.Interfaces;
using CM.Infrastructure.Data.Interfaces;
using CM.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CM.Infrastructure.Data.Repositories
{
    public class Repository<TDbModel, TDomainEntity> : BaseRepository, IRepository<TDomainEntity>
        where TDbModel : BaseCoinBlockModel
        where TDomainEntity : class
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly DbSet<TDbModel> _dbSet;

        public Repository(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dbSet = _dbContext.Set<TDbModel>();
        }

        public async Task<TDomainEntity> CreateAsync(TDomainEntity entity)
        {
            var dbModel = _mapper.Map<TDbModel>(entity);

            await _dbSet.AddAsync(dbModel);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TDomainEntity>(dbModel);
        }

        public async Task<IEnumerable<TDomainEntity>> GetHistoryAsync(short limit, bool isTest)
        {
            var result = BuildHistoryQuery(limit, isTest);

            return await result.ToListAsync();
        }

        private IQueryable<TDomainEntity> BuildHistoryQuery(short limit, bool isTest)
        {
            var query = _dbSet.Where(e => e.IsTest == isTest)
                .OrderByDescending(o => o.CreatedAt)
                .Take(limit)
                .AsNoTracking()
                .Select(entity => _mapper.Map<TDomainEntity>(entity))
                .AsQueryable();

            return query;
        }
    }
}
