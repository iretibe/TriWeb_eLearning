namespace eLearning.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrderId { get; set; }
        public Order Order { get; set; } = default!;

        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; } = default!;
        public Course Course { get; set; } = default!;

        public decimal Price { get; set; }
    }
}
