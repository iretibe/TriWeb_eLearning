using MediatR;

namespace eLearning.Application.Queries
{
    public record VerifyPaystackTransactionQuery(string Reference) : IRequest<bool>;
}
