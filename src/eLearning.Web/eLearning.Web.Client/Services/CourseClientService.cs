using eLearning.Web.Client.Models;
using System.Net.Http.Json;

namespace eLearning.Web.Client.Services
{
    public class CourseClientService : ICourseService
    {
        private readonly HttpClient _http;

        public CourseClientService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
        }

        public async Task<bool> CreateCourseAsync(CourseModel course)
        {
            var response = await _http.PostAsJsonAsync("api/Courses/CreateCourse", course);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/Courses/DeleteCourse/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<CourseModel>> GetAllCoursesAsync()
        {
            var response = await _http.GetFromJsonAsync<List<CourseModel>>("https://localhost:7012/api/Courses/GetAllCourses");

            return response ?? new List<CourseModel>();
        }

        public async Task<CourseModel?> GetCourseByIdAsync(Guid id)
        {
            var response = await _http.GetFromJsonAsync<CourseModel>($"https://localhost:7012/api/Courses/GetCourseById/{id}");

            return response ?? new CourseModel();
        }

        public async Task<bool> UpdateCourseAsync(CourseModel course)
        {
            var response = await _http.PutAsJsonAsync($"api/Courses/UpdateCourse/{course.Id}", course);

            return response.IsSuccessStatusCode;
        }
    }
}
