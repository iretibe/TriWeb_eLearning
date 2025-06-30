using eLearning.Domain.Dtos;
using eLearning.Domain.Entities;
using eLearning.Domain.Enums;
using eLearning.Domain.Repositories;
using eLearning.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Infrastructure.Repositories
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly eLearningContext _context;

        public SubscriptionService(eLearningContext context)
        {
            _context = context;
        }

        public async Task<SubscriptionDto?> GetSubscriptionAsync(string userId)
        {
            var s = await _context.Subscriptions.FirstOrDefaultAsync(s => s.UserId == userId);
            
            return s is null ? null : new SubscriptionDto
            {
                Id = s.Id,
                UserId = s.UserId,
                Type = s.Type,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                IsActive = s.EndDate >= DateTime.UtcNow
            };
        }

        public async Task<bool> IsSubscribedAsync(string userId)
        {
            return await _context.Subscriptions.AnyAsync(s => s.UserId == userId && s.EndDate >= DateTime.UtcNow);
        }

        public async Task SubscribeAsync(string userId, SubscriptionType type)
        {
            var now = DateTime.UtcNow;
            var duration = type == SubscriptionType.Monthly ? TimeSpan.FromDays(30) : TimeSpan.FromDays(365);
            var end = now.Add(duration);

            var existing = await _context.Subscriptions.FirstOrDefaultAsync(s => s.UserId == userId);
            if (existing is null)
            {
                _context.Subscriptions.Add(new Subscription
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Type = type,
                    StartDate = now,
                    EndDate = end
                });
            }
            else
            {
                existing.Type = type;
                existing.StartDate = now;
                existing.EndDate = end;
            }

            await _context.SaveChangesAsync();
        }
    }
}
