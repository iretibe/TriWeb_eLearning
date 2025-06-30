namespace eLearning.Domain.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public string TransactionReference { get; set; } = default!;
        public DateTime OrderDate { get; set; }
        //public List<Guid> CourseIds { get; set; } = new();

        public List<OrderItemDto> Items { get; set; } = new();
    }
}
