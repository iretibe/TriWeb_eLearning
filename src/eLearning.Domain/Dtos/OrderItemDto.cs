namespace eLearning.Domain.Dtos
{
    public class OrderItemDto
    {
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
