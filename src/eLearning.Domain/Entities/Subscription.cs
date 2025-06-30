using eLearning.Domain.Enums;

namespace eLearning.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;

        public SubscriptionType Type { get; set; } = SubscriptionType.Monthly;
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }
        public bool IsActive => EndDate >= DateTime.UtcNow;
    }
}
