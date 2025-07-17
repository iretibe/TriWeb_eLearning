using eLearning.Domain.Dtos;
using eLearning.Domain.Entities;
using eLearning.Domain.Repositories;
using eLearning.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Infrastructure.Repositories
{
    public class VideoContentService : IVideoContentService
    {
        private readonly eLearningContext _context;

        public VideoContentService(eLearningContext context)
        {
            _context = context;
        }

        public async Task AddVideoAsync(VideoContentDto dto)
        {
            var video = new VideoContent
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                VideoUrl = dto.VideoUrl,
                CourseId = dto.CourseId
            };

            _context.VideoContents.Add(video);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VideoContentDto>> GetAllVideoCoursesAsync()
            => await _context.VideoContents
                .Select(v => new VideoContentDto
                {
                    Title = v.Title,
                    VideoUrl = v.VideoUrl,
                    CourseId = v.CourseId,
                    CourseTitle = v.Course.Title
                }).ToListAsync();

        public async Task<List<VideoContentDto>> GetVideosByCourseAsync(Guid courseId)
        {
            return await _context.VideoContents
                .Where(v => v.CourseId == courseId)
                .Select(v => new VideoContentDto
                {
                    Title = v.Title,
                    VideoUrl = v.VideoUrl,
                    CourseId = v.CourseId,
                    CourseTitle = v.Course.Title
                }).ToListAsync();
        }
    }
}
