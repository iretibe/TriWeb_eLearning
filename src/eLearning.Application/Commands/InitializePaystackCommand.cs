using MediatR;

namespace eLearning.Application.Commands
{
    public record InitializePaystackCommand(string Email,
        int Amount, string Reference, string CallbackUrl ) : IRequest<string>;
}
