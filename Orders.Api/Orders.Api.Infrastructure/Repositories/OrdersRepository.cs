using Microsoft.EntityFrameworkCore;
using Orders.Api.Application.Abstractions;
using Orders.Api.Domain.Entities;

namespace Orders.Api.Infrastructure.Repositories
{
    internal class OrdersRepository : IOrdersRepository
    {
        private readonly AppDbContext _dbContext;

        public OrdersRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(OrderEntity entity, CancellationToken ct = default)
        {
            await _dbContext.AddAsync(entity, ct);
        }

        public async Task<OrderEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.Orders.Where(e => e.Id == id).FirstOrDefaultAsync(ct);
        }

        public async Task<OrderEntity[]> GetOrdersAsync(CancellationToken ct = default)
        {
            return await _dbContext.Orders.ToArrayAsync(ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _dbContext.SaveChangesAsync(ct);
        }
    }
}
