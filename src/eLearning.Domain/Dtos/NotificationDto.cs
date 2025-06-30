namespace eLearning.Domain.Dtos
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = default!;
        public string Message { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
