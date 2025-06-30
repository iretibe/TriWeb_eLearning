namespace eLearning.Domain.Dtos
{
    public class PaystackData
    {
        public string Authorization_Url { get; set; } = default!;
        public string Access_Code { get; set; } = default!;
        public string Reference { get; set; } = default!;
    }
}
