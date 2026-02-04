using Mapster;
using Orders.Api.Application.Dto;
using Orders.Api.Main.Models;

namespace Orders.Api.Main.Mapping
{
    public class MappingRegistrator : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateOrderRequest, OrderDto>();
        }
    }
}
