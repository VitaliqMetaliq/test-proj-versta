using Microsoft.EntityFrameworkCore;
using Orders.Api.Domain.Entities;
using Orders.Api.Infrastructure.Configuration;
using Orders.Api.Infrastructure.Converters;

namespace Orders.Api.Infrastructure
{
    internal class AppDbContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                .HaveConversion<UtcDateTimeConverter>();
        }
    }
}
