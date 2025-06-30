using eLearning.Application.Commands;
using eLearning.Application.Exceptions;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly ICourseService _service;

        public CreateCourseCommandHandler(ICourseService service) => _service = service;

        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new CannotSaveEmptyCourseException();
            }

            await _service.CreateCourseAsync(new Domain.Dtos.CreateCourseDto
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                LecturerId = request.LecturerId,
                Duration = request.Duration,
                ImageUrl = request.ImageUrl,
                PublishedDate = DateTime.Now,
                CourseLanguage = request.CourseLanguage,
                CourseLevel = request.CourseLevel
            });

            return request.Id != Guid.Empty ? request.Id : Guid.NewGuid();
        }
    }
}
