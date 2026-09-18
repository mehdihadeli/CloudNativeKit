namespace CloudNativeKit.Security.ApiKey;

public interface IGetApiKeyQuery
{
    Task<ApiKey?> ExecuteAsync(string providedApiKey);
}
