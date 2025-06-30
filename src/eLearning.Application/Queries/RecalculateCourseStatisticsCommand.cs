using MediatR;

namespace eLearning.Application.Queries
{
    public record RecalculateCourseStatisticsCommand(Guid CourseId) : IRequest;
}
