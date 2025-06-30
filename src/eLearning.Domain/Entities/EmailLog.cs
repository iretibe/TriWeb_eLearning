namespace eLearning.Domain.Entities
{
    public class EmailLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string RecipientEmail { get; set; } = default!;
        public string Subject { get; set; } = default!;
        public string Body { get; set; } = default!;
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
