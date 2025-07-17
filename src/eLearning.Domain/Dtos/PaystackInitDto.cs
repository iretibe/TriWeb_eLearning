using System.Text.Json.Serialization;

namespace eLearning.Domain.Dtos
{
    public class PaystackInitDto
    {
        public bool Status { get; set; }
        public string Message { get; set; } = default!;
        public PaystackInitData Data { get; set; } = new();
    }

    public class PaystackInitData
    {
        [JsonPropertyName("authorization_url")]
        public string AuthorizationUrl { get; set; } = default!;

        [JsonPropertyName("access_code")]
        public string AccessCode { get; set; } = default!;

        public string Reference { get; set; } = default!;
    }
}
