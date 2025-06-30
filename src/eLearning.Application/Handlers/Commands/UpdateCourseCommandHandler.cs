using eLearning.Application.Commands;
using eLearning.Application.Exceptions;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly ICourseService _service;

        public UpdateCourseCommandHandler(ICourseService service) => _service = service;

        public async Task Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _service.GetCourseByIdAsync(request.Id);
            if (course == null) 
                throw new CourseIdNotFoundException(request.Id);

            course.Title = request.Dto.Title;
            course.Description = request.Dto.Description;
            course.Price = request.Dto.Price;
            course.Duration = request.Dto.Duration;
            course.ImageUrl = request.Dto.ImageUrl;

            await _service.UpdateCourseAsync(request.Id, request.Dto);
        }
    }
}
