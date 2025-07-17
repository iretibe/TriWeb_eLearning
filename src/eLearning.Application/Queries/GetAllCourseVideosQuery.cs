using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetAllCourseVideosQuery : IRequest<List<VideoContentDto>>;
}
