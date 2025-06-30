using MediatR;

namespace eLearning.Application.Queries
{
    public class GetUserIdByEmailQuery : IRequest<string>
    {
        public string Email { get; set; }

        public GetUserIdByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
