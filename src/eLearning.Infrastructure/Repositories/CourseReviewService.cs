using eLearning.Domain.Dtos;
using eLearning.Domain.Entities;
using eLearning.Domain.Repositories;
using eLearning.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Infrastructure.Repositories
{
    public class CourseReviewService : ICourseReviewService
    {
        private readonly eLearningContext _context;

        public CourseReviewService(eLearningContext context) => _context = context;

        public async Task AddReviewAsync(CreateCourseReviewDto dto)
        {
            var review = new CourseReview
            {
                CourseId = dto.CourseId,
                UserId = dto.UserId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                CreatedAt = DateTime.UtcNow
            };

            _context.CourseReviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(Guid reviewId)
        {
            var review = await _context.CourseReviews.FindAsync(reviewId);

            if (review is not null)
            {
                _context.CourseReviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<double> GetAverageRatingAsync(Guid courseId)
        {
            var ratings = await _context.CourseReviews
                .Where(r => r.CourseId == courseId)
                .Select(r => r.Rating)
                .ToListAsync();

            return ratings.Any() ? ratings.Average() : 0.0;
        }

        public async Task<CourseReviewDto?> GetReviewByIdAsync(Guid reviewId)
        {
            var r = await _context.CourseReviews.FindAsync(reviewId);

            return r is null ? null : new CourseReviewDto
            {
                Id = r.Id,
                CourseId = r.CourseId,
                UserId = r.UserId,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            };
        }

        public async Task<IEnumerable<CourseReviewDto>> GetReviewsByCourseAsync(Guid courseId)
        {
            return await _context.CourseReviews
                .Where(r => r.CourseId == courseId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new CourseReviewDto
                {
                    Id = r.Id,
                    CourseId = r.CourseId,
                    UserId = r.UserId,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<int> GetTotalReviewCountAsync(Guid courseId)
        {
            return await _context.CourseReviews.CountAsync(r => r.CourseId == courseId);
        }
    }
}
