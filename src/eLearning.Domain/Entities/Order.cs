namespace eLearning.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;

        public decimal TotalAmount { get; set; }
        public string TransactionReference { get; set; } = default!;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
