using eLearning.Application.Commands;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class MarkOrderAsPaidCommandHandler : IRequestHandler<MarkOrderAsPaidCommand>
    {
        private readonly IOrderService _service;

        public MarkOrderAsPaidCommandHandler(IOrderService service) => _service = service;

        public async Task Handle(MarkOrderAsPaidCommand request, CancellationToken cancellationToken)
        {
            await _service.MarkOrderAsPaidAsync(request.OrderId, request.TransactionReference);
        }
    }
}
