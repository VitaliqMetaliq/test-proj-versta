namespace Orders.Api.Main.Models
{
    public record CreateOrderRequest
    {
        public string SenderCity { get; init; } = string.Empty;
        public string SenderAddress { get; init; } = string.Empty;
        public string ReceiverCity { get; init; } = string.Empty;
        public string ReceiverAddress { get; init; } = string.Empty;
        public float Weight { get; init; }
        public DateTime PickupDate { get; init; }
    }
}
