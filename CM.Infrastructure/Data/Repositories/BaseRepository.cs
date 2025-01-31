
using CM.Infrastructure.Data.Interfaces;

namespace CM.Infrastructure.Data.Repositories
{
    public class BaseRepository: IDisposable
    {
        private readonly IApplicationDbContext _dbContext;
        private bool _disposed = false;

        public BaseRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
