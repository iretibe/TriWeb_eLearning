using Microsoft.AspNetCore.Components;

namespace eLearning.UI.Services
{
    public interface IUrlBuilderService
    {
        string BuildAuthUrl(string path, Dictionary<string, object?>? queryParams = null);
        string NormalizeReturnUrl(string? returnUrl);
    }

    public class UrlBuilderService : IUrlBuilderService
    {
        private readonly NavigationManager _navigationManager;

        public UrlBuilderService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public string BuildAuthUrl(string path, Dictionary<string, object?>? queryParams = null)
        {
            // Ensure BaseUri ends without trailing slash
            var baseUri = _navigationManager.BaseUri.TrimEnd('/');
            var url = $"{baseUri}/{path}";

            if (queryParams?.Count > 0)
            {
                var queryString = string.Join("&", queryParams.Select(kv =>
                    $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value?.ToString() ?? "")}"));
                url += $"?{queryString}";
            }

            return url;
        }

        public string NormalizeReturnUrl(string? returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl) || !returnUrl.StartsWith("/"))
            {
                return "/";
            }
            return returnUrl;
        }
    }
}
