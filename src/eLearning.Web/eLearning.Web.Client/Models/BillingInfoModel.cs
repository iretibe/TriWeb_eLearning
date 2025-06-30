namespace eLearning.Web.Client.Models
{
    public class BillingInfoModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string SubscriptionType { get; set; } = "monthly";
    }
}
