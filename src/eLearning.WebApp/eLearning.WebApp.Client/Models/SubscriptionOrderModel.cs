namespace eLearning.WebApp.Client.Models
{
    public class SubscriptionOrderModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = default!;
        public Guid CourseId { get; set; }
        public string SubscriptionType { get; set; } = "monthly";
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
        public string? TransactionReference { get; set; }

        // Billing info fields
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string State { get; set; } = default!;
        public string PostCode { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Company { get; set; }
        public string? Notes { get; set; }
    }
}
