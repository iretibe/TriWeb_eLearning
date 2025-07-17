namespace eLearning.UI.Client.Services
{
    public class AppSettingsService
    {
        public string BackendUrl { get; }
        public string FrontendUrl { get; }

        public AppSettingsService(IConfiguration config)
        {
            BackendUrl = config["ApiUrls:BackendUrl"]
                ?? throw new InvalidOperationException("BackendUrl is not configured.");

            FrontendUrl = config["ApiUrls:FrontendUrl"]
                ?? throw new InvalidOperationException("FrontendUrl is not configured.");
        }
    }
}
