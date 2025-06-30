namespace eLearning.Web.Client.Models
{
    public class CourseModel : CreateCourseModel
    {
        public bool IsRetired { get; set; }
        public DateTime? RetireDate { get; set; }
        public string LecturerId { get; set; } = string.Empty;
    }
}
