using eLearning.Domain.Enums;

namespace eLearning.Domain.Dtos
{
    public class SubscriptionDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = default!;
        public SubscriptionType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
