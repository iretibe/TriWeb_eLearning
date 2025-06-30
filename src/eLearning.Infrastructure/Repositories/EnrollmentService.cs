using eLearning.Domain.Dtos;
using eLearning.Domain.Entities;
using eLearning.Domain.Repositories;
using eLearning.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Infrastructure.Repositories
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly eLearningContext _context;

        public EnrollmentService(eLearningContext context)
        {
            _context = context;
        }

        public async Task EnrollLearnerAsync(string userId, Guid courseId)
        {
            if (!await _context.Enrollments.AnyAsync(e => e.LearnerId == userId && e.CourseId == courseId))
            {
                _context.Enrollments.Add(new Enrollment
                {
                    Id = Guid.NewGuid(),
                    LearnerId = userId,
                    CourseId = courseId,
                    EnrolledOn = DateTime.UtcNow
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EnrollmentDto>> GetEnrollmentsByUserAsync(string userId)
        {
            return await _context.Enrollments
                .Where(e => e.LearnerId == userId)
                .Select(e => new EnrollmentDto
                {
                    Id = e.Id,
                    LearnerId = e.LearnerId,
                    CourseId = e.CourseId,
                    EnrolledOn = e.EnrolledOn
                }).ToListAsync();
        }

        public async Task<bool> IsUserEnrolledAsync(string userId, Guid courseId)
        {
            return await _context.Enrollments.AnyAsync(e => e.LearnerId == userId && e.CourseId == courseId);
        }
    }
}
