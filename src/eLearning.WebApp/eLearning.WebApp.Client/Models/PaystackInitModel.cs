﻿using System.Text.Json.Serialization;

namespace eLearning.WebApp.Client.Models
{
    public class PaystackInitModel
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public PaystackInitData Data { get; set; } = new();
    }

    public class PaystackInitData
    {
        [JsonPropertyName("authorization_url")]
        public string AuthorizationUrl { get; set; } = string.Empty;

        [JsonPropertyName("access_code")]
        public string AccessCode { get; set; } = string.Empty;

        public string Reference { get; set; } = string.Empty;
    }
}
