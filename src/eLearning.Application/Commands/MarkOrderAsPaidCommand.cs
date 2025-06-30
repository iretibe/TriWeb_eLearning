using MediatR;

namespace eLearning.Application.Commands
{
    public class MarkOrderAsPaidCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public string TransactionReference { get; set; } = default!;
    }
}
