using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public class GetCoursesByIdQuery : IRequest<CourseDto>
    {
        public Guid Id { get; set; }

        public GetCoursesByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
