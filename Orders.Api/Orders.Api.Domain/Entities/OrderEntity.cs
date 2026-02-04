namespace Orders.Api.Domain.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string SenderCity { get; set; } = string.Empty;
        public string SenderAddress { get; set; } = string.Empty;
        public string ReceiverCity { get; set; } = string.Empty;
        public string ReceiverAddress { get; set; } = string.Empty;
        public float Weight { get; set; }
        public DateTime PickupDate { get; set; }
    }
}
