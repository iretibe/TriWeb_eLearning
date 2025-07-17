using eLearning.Domain.Dtos;
using eLearning.Domain.Entities;
using eLearning.Domain.Repositories;
using eLearning.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace eLearning.Infrastructure.Repositories
{
    public class CourseService : ICourseService
    {
        private readonly eLearningContext _context;
        private readonly IConfiguration _configuration;

        public CourseService(eLearningContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<double> CalculateCourseRatingAsync(Guid courseId)
        {
            // Assuming ratings are stored in a related table: e.g., CourseReviews
            var ratings = await _context.CourseReviews
                .Where(r => r.CourseId == courseId)
                .Select(r => r.Rating)
                .ToListAsync();

            return ratings.Any() ? ratings.Average() : 0.0;
        }

        public async Task CreateCourseAsync(CreateCourseDto dto)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                LecturerId = dto.LecturerId,
                ImageUrl = dto.ImageUrl,
                Duration = dto.Duration,
                Rating = 0,
                ReviewsCount = 0,
                StudentsEnrolled = 0,
                PublishedDate = DateTime.Now,
                CourseLanguage = dto.CourseLanguage,
                CourseLevel = dto.CourseLevel
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(Guid courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course is not null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
            => await _context.Courses
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Price = c.Price,
                    IsRetired = c.IsRetired,
                    RetireDate = c.RetireDate,
                    LecturerId = c.LecturerId,
                    Duration = c.Duration,
                    ImageUrl = c.ImageUrl,
                    Rating = c.Rating,
                    ReviewsCount = c.ReviewsCount,
                    StudentsEnrolled = c.StudentsEnrolled,
                    LecturerName = c.Lecturer.UserName!,
                    PublishedDate = c.PublishedDate,
                    CourseLanguage = c.CourseLanguage,
                    CourseLevel = c.CourseLevel
                }).ToListAsync();
        
        public async Task<CourseDto?> GetCourseByIdAsync(Guid courseId)
        {
            var course = await _context.Courses
                .Include(c => c.Lecturer)
                .FirstOrDefaultAsync(c => c.Id == courseId);

            return course is null ? null : new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                IsRetired = course.IsRetired,
                RetireDate = course.RetireDate,
                LecturerId = course.LecturerId,
                Duration = course.Duration,
                ImageUrl = course.ImageUrl,
                Rating = course.Rating,
                ReviewsCount = course.ReviewsCount,
                StudentsEnrolled = course.StudentsEnrolled,
                LecturerName = course.Lecturer?.UserName ?? "Unknown",
                PublishedDate = course.PublishedDate,
                CourseLanguage = course.CourseLanguage,
                CourseLevel = course.CourseLevel
            };
        }

        public async Task<List<CourseDto>> GetCoursesByIdsAsync(List<Guid> ids)
        {
            return await _context.Courses
               .Where(c => ids.Contains(c.Id))
               .Select(c => new CourseDto
               {
                   Id = c.Id,
                   Title = c.Title,
                   Description = c.Description,
                   Price = c.Price,
                   ImageUrl = c.ImageUrl
               })
               .ToListAsync();
        }

        public async Task<int> GetReviewCountAsync(Guid courseId)
        {
            return await _context.CourseReviews.CountAsync(r => r.CourseId == courseId);
        }

        public async Task<int> GetStudentEnrollmentCountAsync(Guid courseId)
        {
            return await _context.Enrollments.CountAsync(e => e.CourseId == courseId);
        }

        public async Task<List<CourseDto>> GetUserCoursesAsync(string userId)
        {
            var query = await _context.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .SelectMany(o => o.Items, (order, item) => new { order, item })
                .Select(x => new CourseDto
                {
                    Id = x.item.CourseId,
                    Title = x.item.CourseTitle,
                    Description = x.item.Course.Description,
                    Price = x.item.Course.Price,
                    ImageUrl = x.item.Course.ImageUrl,
                    LecturerId = x.item.Course.LecturerId,
                    LecturerName = x.item.Course.Lecturer.UserName!,
                    Rating = x.item.Course.Rating,
                    ReviewsCount = x.item.Course.ReviewsCount,
                    Duration = x.item.Course.Duration,
                    StudentsEnrolled = x.item.Course.StudentsEnrolled,
                    PublishedDate = x.item.Course.PublishedDate,
                    CourseLanguage = x.item.Course.CourseLanguage,
                    CourseLevel = x.item.Course.CourseLevel,
                    VideoUrls = x.item.Course.Videos
                        .OrderBy(v => v.Title) // or any preferred field
                        .Take(1)
                        .Select(v => $"{_configuration["ApiUrls:BackendUrl"]}{v.VideoUrl}")
                        .ToList()
                })
                .ToListAsync();

            //var query = await _context.Enrollments
            //    .Where(e => e.LearnerId == userId)
            //    .Include(e => e.Course)
            //        .ThenInclude(c => c.Videos)
            //    .Select(e => new CourseDto
            //    {
            //        Id = e.Course.Id,
            //        Title = e.Course.Title,
            //        Description = e.Course.Description,
            //        Price = e.Course.Price,
            //        ImageUrl = e.Course.ImageUrl,
            //        LecturerId = e.Course.LecturerId,
            //        LecturerName = e.Course.Lecturer.UserName!,
            //        Rating = e.Course.Rating,
            //        ReviewsCount = e.Course.ReviewsCount,
            //        Duration = e.Course.Duration,
            //        StudentsEnrolled = e.Course.StudentsEnrolled,
            //        PublishedDate = e.Course.PublishedDate,
            //        CourseLanguage = e.Course.CourseLanguage,
            //        CourseLevel = e.Course.CourseLevel,
            //        //VideoUrls = e.Course.Videos.Select(v => v.VideoUrl).ToList()
            //        VideoUrls = e.Course.Videos.Select(v => $"{_configuration.GetSection("ApiUrls").GetSection("BackendUrl").Value}{v.VideoUrl}").ToList()
            //    })
            //    .ToListAsync();

            return query;
        }

        public async Task RecalculateCourseStatisticsAsync(Guid courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null) return;

            course.Rating = await CalculateCourseRatingAsync(courseId);
            course.ReviewsCount = await GetReviewCountAsync(courseId);
            course.StudentsEnrolled = await GetStudentEnrollmentCountAsync(courseId);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Guid courseId, UpdateCourseDto dto)
        {
            var course = await _context.Courses.FindAsync(courseId);

            if (course is null) return;
            course.Title = dto.Title;
            course.Description = dto.Description;
            course.Price = dto.Price;
            course.Duration = dto.Duration;
            course.ImageUrl = dto.ImageUrl;
            course.LecturerId = dto.LecturerId;
            course.PublishedDate = dto.PublishedDate;
            course.CourseLanguage = dto.CourseLanguage;
            course.CourseLevel = dto.CourseLevel;

            await _context.SaveChangesAsync();
        }
    }
}
