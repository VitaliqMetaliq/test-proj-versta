namespace Orders.Api.Application.Dto
{
    public record OrderDto
    {
        public int Id { get; init; }
        public string SenderCity { get; init; } = string.Empty;
        public string SenderAddress { get; init; } = string.Empty;
        public string ReceiverCity { get; init; } = string.Empty;
        public string ReceiverAddress { get; init; } = string.Empty;
        public float Weight { get; init; }
        public DateTime PickupDate { get; init; }
    }
}
