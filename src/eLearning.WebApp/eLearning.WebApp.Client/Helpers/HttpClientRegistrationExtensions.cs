namespace eLearning.WebApp.Client.Helpers
{
    public static class HttpClientRegistrationExtensions
    {
        public static IServiceCollection AddBackendHttpClient<TClient>(this IServiceCollection services, IConfiguration config)
            where TClient : class
        {
            var backendUrl = config["ApiUrls:BackendUrl"];

            if (string.IsNullOrWhiteSpace(backendUrl))
            {
                throw new InvalidOperationException("Backend URL is not configured. Please set 'ApiUrls:BackendUrl' in appsettings.json.");
            }

            services.AddHttpClient<TClient>(client =>
            {
                client.BaseAddress = new Uri(backendUrl);
            });

            return services;
        }
    }
}
