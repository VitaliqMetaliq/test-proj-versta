using FluentValidation;
using Orders.Api.Main.Models;

namespace Orders.Api.Main.Validators
{
    internal sealed class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.SenderCity)
                .NotEmpty().WithMessage("Sender city required")
                .MaximumLength(100);

            RuleFor(x => x.SenderAddress)
                .NotEmpty().WithMessage("Sender address required")
                .MaximumLength(500);

            RuleFor(x => x.ReceiverCity)
                .NotEmpty().WithMessage("Receiver city required")
                .MaximumLength(100);

            RuleFor(x => x.ReceiverAddress)
                .NotEmpty().WithMessage("Receiver address required")
                .MaximumLength(500);

            RuleFor(x => x.Weight)
                .NotEmpty().WithMessage("Weight required");

            RuleFor(x => x.PickupDate)
                .NotEmpty().WithMessage("Pickup date required");
        }
    }
}
