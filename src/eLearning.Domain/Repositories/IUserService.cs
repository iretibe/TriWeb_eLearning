using eLearning.Domain.Dtos;

namespace eLearning.Domain.Repositories
{
    public interface IUserService
    {
        Task<string> GetUserIdByEmailAsync(string email);
        Task<ApplicationUserDto?> GetUserByIdAsync(string userId);
        Task<IEnumerable<ApplicationUserDto>> GetAllUsersAsync();
        Task AssignRoleAsync(string userId, string role);
        Task<IEnumerable<string>> GetUserRolesAsync(string userId);
    }
}
