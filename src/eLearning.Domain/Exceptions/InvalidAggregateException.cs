namespace eLearning.Domain.Exceptions
{
    public class InvalidAggregateException : DomainException
    {
        public InvalidAggregateException(Guid id) : base($"The aggregate id '{id}' is invalid.")
        {
        }
    }
}
