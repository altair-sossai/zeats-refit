using Refit;
using Zeats.Json;

namespace Zeats.Refit.Context;

public class RefitContext
{
    public RefitContext(string apiUrl, RefitSettings refitSettings = null)
    {
        ApiUrl = apiUrl;
        Settings = refitSettings ?? new RefitSettings
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