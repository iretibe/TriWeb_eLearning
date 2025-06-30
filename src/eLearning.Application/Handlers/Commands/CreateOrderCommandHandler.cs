using eLearning.Application.Commands;
using eLearning.Domain.Entities;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
            => _orderService = orderService;

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new SubscriptionOrder
            {
                Id = Guid.NewGuid(),
                CourseId = request.CourseId,
                UserId = request.UserId,
                SubscriptionType = request.SubscriptionType,
                Price = request.Price,
                OrderDate = DateTime.UtcNow,
                Status = "Pending", // or any default status

                FirstName = request.FirstName,
                LastName = request.LastName,
                Country = request.Country,
                Street = request.Street,
                State = request.State,
                PostCode = request.PostCode,
                Phone = request.Phone,
                Email = request.Email,
                Company = request.Company,
                Notes = request.Notes
            };

            return await _orderService.CreateOrderAsync(order);
        }
    }
}
