using Orders.Api.Application.Dto;

namespace Orders.Api.Application.Abstractions
{
    public interface IOrdersService
    {
        Task<OrderDto?> GetOrderByIdAsync(int id, CancellationToken ct = default);
        Task CreateOrderAsync(OrderDto order, CancellationToken ct = default);
        Task<OrderDto[]> GetOrdersAsync(CancellationToken ct = default);
    }
}
