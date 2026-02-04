using Orders.Api.Domain.Entities;

namespace Orders.Api.Application.Abstractions
{
    public interface IOrdersRepository
    {
        Task<OrderEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task CreateAsync(OrderEntity entity, CancellationToken ct = default);
        Task<OrderEntity[]> GetOrdersAsync(CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
