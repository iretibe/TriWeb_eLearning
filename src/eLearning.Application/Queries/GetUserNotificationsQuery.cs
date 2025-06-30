using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetUserNotificationsQuery(string UserId) : IRequest<List<NotificationDto>>;
}
