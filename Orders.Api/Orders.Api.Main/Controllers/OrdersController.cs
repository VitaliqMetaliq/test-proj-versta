using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Orders.Api.Application.Abstractions;
using Orders.Api.Application.Dto;
using Orders.Api.Main.Models;

namespace Orders.Api.Main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOrderRequest> _validator;

        public OrdersController(IOrdersService orderService, IMapper mapper, IValidator<CreateOrderRequest> validator)
        {
            _orderService = orderService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderDto>> GetOrderByIdAsync([FromRoute] int id, CancellationToken ct)
        {
            var order = await _orderService.GetOrderByIdAsync(id, ct);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrderDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderDto[]>> GetOrdersAsync(CancellationToken ct)
        {
            var orders = await _orderService.GetOrdersAsync(ct);
            return Ok(orders);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateOrderAsync([FromBody] CreateOrderRequest request, CancellationToken ct)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var dto = _mapper.Map<OrderDto>(request);
            await _orderService.CreateOrderAsync(dto, ct);
            return Ok();
        }
    }
}
