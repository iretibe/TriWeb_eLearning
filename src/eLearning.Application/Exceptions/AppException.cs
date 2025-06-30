namespace eLearning.Application.Exceptions
{
    public abstract class AppException : Exception
    {
        public virtual string Code { get; }

        protected AppException(string code) : base(code)
        {
            Code = code;
        }
    }
}
