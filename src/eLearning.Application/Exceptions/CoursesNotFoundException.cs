namespace eLearning.Application.Exceptions
{
    public class CoursesNotFoundException : AppException
    {
        public CoursesNotFoundException() : base("Courses were not found.")
        {
        }
    }
}
