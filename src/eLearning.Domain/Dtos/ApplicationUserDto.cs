namespace eLearning.Domain.Dtos
{
    public class ApplicationUserDto
    {
        public string Id { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
