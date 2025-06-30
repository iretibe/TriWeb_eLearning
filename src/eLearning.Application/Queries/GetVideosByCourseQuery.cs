using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetVideosByCourseQuery(Guid CourseId) : IRequest<List<VideoContentDto>>;
}
