using CM.Infrastructure.Data.Interfaces;
using CM.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CM.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BitcoinBlockModel> BitcoinBlocks { get; set; } 
        public DbSet<LitecoinBlockModel> LitecoinBlocks { get; set; }
        public DbSet<DashcoinBlockModel> DashcoinBlocks { get; set; }
        public DbSet<DogecoinBlockModel> DogecoinBlocks { get; set; }
        public DbSet<EthcoinBlockModel> EthcoinBlocks { get; set; }
        public DbSet<CypherBlockModel> CypherBlocks { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                .HavePrecision(28, 10);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
