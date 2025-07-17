using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class VerifyPaystackTransactionQueryHandler : IRequestHandler<VerifyPaystackTransactionQuery, bool>
    {
        private readonly IPaymentGatewayService _paymentService;

        public VerifyPaystackTransactionQueryHandler(IPaymentGatewayService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<bool> Handle(VerifyPaystackTransactionQuery request, CancellationToken cancellationToken)
        {
            return await _paymentService.VerifyPaystackTransactionAsync(request.Reference);
        }
    }
}