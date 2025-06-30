using eLearning.UI.Client.Models;
using System.Net.Http.Json;

namespace eLearning.UI.Client.Services
{
    public class CourseClientService : ICourseService
    {
        private readonly HttpClient _http;
        //private readonly string _baseUrl;

        public CourseClientService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            //var apiBase = configuration["ApiUrls:BackendUrl"];
            //_baseUrl = $"{apiBase}/api/Courses";
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
            var response = await _http.GetFromJsonAsync<List<CourseModel>>("api/Courses/GetAllCourses");

            return response ?? new List<CourseModel>();
        }

        public async Task<CourseModel?> GetCourseByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<CourseModel>($"api/Courses/GetCourseById/{id}");
        }

        public async Task<bool> UpdateCourseAsync(CourseModel course)
        {
            var response = await _http.PutAsJsonAsync($"api/Courses/UpdateCourse/{course.Id}", course);

            return response.IsSuccessStatusCode;
        }
    }
}
