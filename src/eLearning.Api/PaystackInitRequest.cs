namespace eLearning.Api
{
    public class PaystackInitRequest
    {
        public int AmountInKobo { get; set; }
        public string Email { get; set; } = default!;
        public string Reference { get; set; } = default!;
    }
}
