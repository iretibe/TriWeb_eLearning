namespace eLearning.Domain.Dtos
{
    public class PaystackInitResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = default!;
        public PaystackData Data { get; set; } = default!;
    }
}
