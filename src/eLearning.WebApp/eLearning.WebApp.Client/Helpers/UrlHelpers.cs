namespace eLearning.WebApp.Client.Helpers
{
    public static class UrlHelpers
    {
        public static string BuildImageUrl(string backendBaseUrl, string relativeImagePath)
        {
            return $"{backendBaseUrl.TrimEnd('/')}/{relativeImagePath.TrimStart('/')}";
        }
    }
}
