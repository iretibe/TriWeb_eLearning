namespace eLearning.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public virtual string Message { get; }

        public DomainException(string message) : base(message)
        {
            Message = message;
        }
    }
}
