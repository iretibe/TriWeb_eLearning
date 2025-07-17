namespace eLearning.Domain.Dtos
{
    public class InitializePaymentRequestDto
    {
        public string Email { get; set; } = default!;
        public int Amount { get; set; }
        public string Reference { get; set; } = default!;
        public string CallbackUrl { get; set; } = default!;
    }
}
