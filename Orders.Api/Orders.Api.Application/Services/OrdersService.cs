using MapsterMapper;
using Orders.Api.Application.Abstractions;
using Orders.Api.Application.Dto;
using Orders.Api.Domain.Entities;

namespace Orders.Api.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(OrderDto order, CancellationToken ct = default)
        {
            var entity = _mapper.Map<OrderEntity>(order);
            await _ordersRepository.CreateAsync(entity, ct);
            await _ordersRepository.SaveChangesAsync(ct);
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _ordersRepository.GetByIdAsync(id, ct);
            return entity == null ? null : _mapper.Map<OrderDto>(entity);
        }

        public async Task<OrderDto[]> GetOrdersAsync(CancellationToken ct = default)
        {
            var entities = await _ordersRepository.GetOrdersAsync(ct);
            return _mapper.Map<OrderDto[]>(entities);
        }
    }
}
