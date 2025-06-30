using MediatR;

namespace eLearning.Application.Queries
{
    public class IsSubscribedQuery : IRequest<bool>
    {
        public string UserId { get; set; } = default!;
    }
}
