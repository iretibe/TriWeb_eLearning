namespace eLearning.WebApp.Client.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public string TransactionReference { get; set; } = default!;
        public DateTime OrderDate { get; set; }
        public List<Guid> CourseIds { get; set; } = new();

        public List<OrderItemModel> Items { get; set; } = new();
    }

    public class OrderItemModel
    {
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
