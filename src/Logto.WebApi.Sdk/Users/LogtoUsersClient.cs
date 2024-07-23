using Logto.WebApi.Sdk.Common;
using Microsoft.Extensions.Options;

namespace Logto.WebApi.Sdk.Users;

public class LogtoUsersClient : ApiClient
{
    public LogtoUsersClient(HttpClient httpClient, IOptions<LogtoEndpoint> logtoEndpoint)
        : base(httpClient, logtoEndpoint)
    {
    }

    /// <summary>
    /// https://openapi.logto.io/operation/operation-listusers
    /// </summary>
    public async Task<IEnumerable<User>?> GetUsersAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/users");

        return await SendRequestAsync<IEnumerable<User>>(request);
    }

    /// <summary>
    /// https://openapi.logto.io/operation/operation-getuser
    /// </summary>
    public async Task<User?> GetUserAsync(string userId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/users/{userId}");

        return await SendRequestAsync<User>(request);
    }
}
