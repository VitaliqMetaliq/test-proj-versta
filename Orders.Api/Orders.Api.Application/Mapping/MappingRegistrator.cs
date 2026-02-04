using Mapster;
using Orders.Api.Application.Dto;
using Orders.Api.Domain.Entities;

namespace Orders.Api.Application.Mapping
{
    public class MappingRegistrator : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<OrderEntity, OrderDto>();
            config.NewConfig<OrderDto, OrderEntity>();
        }
    }
}
