using eLearning.Application.Commands;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class AddVideoCommandHandler : IRequestHandler<AddVideoCommand>
    {
        private readonly IVideoContentService _service;

        public AddVideoCommandHandler(IVideoContentService service) =>_service = service;

        public async Task Handle(AddVideoCommand request, CancellationToken cancellationToken)
        {
            var dto = new VideoContentDto
            {
                Title = request.Title,
                VideoUrl = request.VideoUrl,
                CourseId = request.CourseId
            };

            await _service.AddVideoAsync(dto);
        }
    }
}
