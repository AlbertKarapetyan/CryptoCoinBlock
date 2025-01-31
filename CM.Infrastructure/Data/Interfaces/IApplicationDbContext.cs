using Microsoft.EntityFrameworkCore;

namespace CM.Infrastructure.Data.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
