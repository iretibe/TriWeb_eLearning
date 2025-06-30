namespace eLearning.Application.Exceptions
{
    public class CourseIdNotFoundException : AppException
    {
        public CourseIdNotFoundException(Guid id) : base($"Course with ID: `{id}` cannot be found.")
        {
        }
    }
}
