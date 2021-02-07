using Refit;
using Zeats.Json;

namespace Zeats.Refit.Context
{
    public class RefitContext
    {
        public RefitContext(string apiUrl, RefitSettings refit = null)
        {
            ApiUrl = apiUrl;
            Settings = refit ?? new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(JsonConfiguration.Options)
            };
        }

        public string ApiUrl { get; set; }
        public RefitSettings Settings { get; set; }

        public T CreateServer<T>()
        {
            return Settings == null
                ? RestService.For<T>(ApiUrl)
                : RestService.For<T>(ApiUrl, Settings);
        }
    }
}