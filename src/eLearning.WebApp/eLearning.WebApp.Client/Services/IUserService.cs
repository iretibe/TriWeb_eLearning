namespace eLearning.WebApp.Client.Services
{
    public interface IUserService
    {
        Task<string> GetUserIdByEmailAsync(string email);
    }
}
