using MediatR;

namespace eLearning.Application.Queries
{
    public record GetStudentEnrollmentCountQuery(Guid CourseId) : IRequest<int>;
}
