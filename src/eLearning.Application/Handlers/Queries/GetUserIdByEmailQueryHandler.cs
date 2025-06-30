using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetUserIdByEmailQueryHandler : IRequestHandler<GetUserIdByEmailQuery, string>
    {
        private readonly IUserService _userService;

        public GetUserIdByEmailQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Handle(GetUserIdByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserIdByEmailAsync(request.Email);
        }
    }
}
