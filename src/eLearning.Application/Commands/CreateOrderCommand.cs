using eLearning.Domain.Entities;
using MediatR;

namespace eLearning.Application.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid CourseId { get; set; }
        public string UserId { get; set; } = default!;
        public string SubscriptionType { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = default!;
        public string? TransactionReference { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string State { get; set; } = default!;
        public string PostCode { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Company { get; set; } = default!;
        public string Notes { get; set; } = default!;
    }
}
