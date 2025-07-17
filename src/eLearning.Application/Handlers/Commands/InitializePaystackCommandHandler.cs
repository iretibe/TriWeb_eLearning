using eLearning.Application.Commands;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class InitializePaystackCommandHandler : IRequestHandler<InitializePaystackCommand, string>
    {
        private readonly IPaymentGatewayService _paymentService;

        public InitializePaystackCommandHandler(IPaymentGatewayService paymentService)
            => _paymentService = paymentService;

        public async Task<string> Handle(InitializePaystackCommand request, CancellationToken cancellationToken)
        {
            return await _paymentService.InitializePaystackAsync(
                request.Email,
                request.Amount,
                request.Reference,
                request.CallbackUrl
            );
        }
    }
}