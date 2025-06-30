using eLearning.Application.Commands;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class CreateOneTimePurchaseOrderCommandHandler : IRequestHandler<CreateOneTimePurchaseOrderCommand, Guid>
    {
        private readonly IOrderService _orderService;

        public CreateOneTimePurchaseOrderCommandHandler(IOrderService orderService)
            => _orderService = orderService;

        public async Task<Guid> Handle(CreateOneTimePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            var orderDto = request.Order;

            // Ensure all course details are present in the payload
            if (orderDto.Items == null || !orderDto.Items.Any())
                throw new ArgumentException("No order items were provided.");

            // Call the service directly with detailed course info
            var orderId = await _orderService.CreateOneTimePurchaseOrderAsync(
                orderDto.UserId,
                orderDto.Items.Select(i => new CourseDto
                {
                    Id = i.CourseId,
                    Title = i.CourseTitle,
                    Price = i.Price
                }).ToList(),
                orderDto.TransactionReference);

            return orderId;
        }
    }
}
