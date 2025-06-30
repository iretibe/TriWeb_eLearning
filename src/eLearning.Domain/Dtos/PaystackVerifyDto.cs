namespace eLearning.Domain.Dtos
{
    public class PaystackVerifyDto
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public PaystackTransactionData? Data { get; set; }
    }

    public class PaystackTransactionData
    {
        public string Status { get; set; } = string.Empty; // e.g., "success"
        public string Reference { get; set; } = string.Empty;
        public string GatewayResponse { get; set; } = string.Empty;
        public int Amount { get; set; } // In kobo
        public string Currency { get; set; } = string.Empty;
        public PaystackCustomer Customer { get; set; } = new();
        public DateTime PaidAt { get; set; }
        public string Channel { get; set; } = string.Empty;
    }

    public class PaystackCustomer
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
