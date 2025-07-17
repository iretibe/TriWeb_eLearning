namespace eLearning.Domain.Dtos
{
    public class PaystackVerifyNewDto
    {
        public bool Status { get; set; }
        public string Message { get; set; } = default!;
        public VerifyData Data { get; set; } = default!;

        public class VerifyData
        {
            public string Status { get; set; } = default!; // success, failed
            public string Reference { get; set; } = default!;
            public int Amount { get; set; }
            public string GatewayResponse { get; set; } = default!;
            public string PaidAt { get; set; } = default!;
        }
    }
}
