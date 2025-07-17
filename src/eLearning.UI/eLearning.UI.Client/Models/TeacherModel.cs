namespace eLearning.UI.Client.Models
{
    public class TeacherModel
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new();

        // UI binding helper
        public string SelectedRole
        {
            get => Roles.FirstOrDefault() ?? "";
            set => Roles = new List<string> { value };
        }
    }
}
