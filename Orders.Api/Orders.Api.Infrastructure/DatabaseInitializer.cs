using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Orders.Api.Infrastructure
{
    public static class DatabaseInitializer
    {
        public static async Task InitAsync(IServiceProvider scopeServiceProvider)
        {
            var context = scopeServiceProvider.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
        }
    }
}
