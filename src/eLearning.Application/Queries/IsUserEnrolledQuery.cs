using MediatR;

namespace eLearning.Application.Queries
{
    public record IsUserEnrolledQuery(string UserId, Guid CourseId) : IRequest<bool>;
}
