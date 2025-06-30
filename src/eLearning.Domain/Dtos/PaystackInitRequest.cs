namespace eLearning.Domain.Dtos
{
    public class PaystackInitRequest
    {
        public string Email { get; set; } = default!;
        public int Amount { get; set; } // in kobo (NGN) or cents
        public string CallbackUrl { get; set; } = default!;
        public string Reference { get; set; } = Guid.NewGuid().ToString();
    }
}
