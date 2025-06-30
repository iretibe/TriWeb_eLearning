namespace eLearning.Application.Exceptions
{
    public class CannotSaveEmptyCourseException : AppException
    {
        public CannotSaveEmptyCourseException() : base($"Empty course records cannot be saved.")
        {
        }
    }
}
