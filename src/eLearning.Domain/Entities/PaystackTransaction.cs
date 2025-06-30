namespace eLearning.Domain.Entities
{
    public class PaystackTransaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Reference { get; set; } = default!;
        public string Status { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Email { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
