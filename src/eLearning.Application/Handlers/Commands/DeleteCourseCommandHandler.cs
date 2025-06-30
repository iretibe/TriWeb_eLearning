using eLearning.Application.Commands;
using eLearning.Application.Exceptions;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly ICourseService _service;

        public DeleteCourseCommandHandler(ICourseService service) => _service = service;

        public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _service.GetCourseByIdAsync(request.Id);
            if (course == null)
                throw new CourseIdNotFoundException(request.Id);

            await _service.DeleteCourseAsync(request.Id);
        }
    }
}
