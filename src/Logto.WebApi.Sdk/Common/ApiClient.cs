using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Logto.WebApi.Sdk.Authentication;
using Microsoft.Extensions.Options;

namespace Logto.WebApi.Sdk.Common;

public abstract class ApiClient
{
    protected readonly HttpClient HttpClient;
    protected readonly LogtoEndpoint LogtoEndpoint;
    private Token? _currentToken;

    protected ApiClient(HttpClient httpClient, IOptions<LogtoEndpoint> logtoEndpoint)
    {
        HttpClient = httpClient;
        LogtoEndpoint = logtoEndpoint.Value;
    }

    /// <summary>
    /// See https://openapi.logto.io/authentication.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    protected async Task AuthenticateAsync()
    {
        var values = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("resource", new Uri(LogtoEndpoint.Url).AbsoluteUri + "api"),
            new KeyValuePair<string, string>("scope", "all")
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "/oidc/token")
        {
            Content = new FormUrlEncodedContent(values),
        };

        var authenticationString = $"{LogtoEndpoint.ClientId}:{LogtoEndpoint.ClientSecret}";
        var base64EncodedAuthenticationString = Convert.ToBase64String(Encoding.ASCII.GetBytes(authenticationString));

        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

        var response = await HttpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        var authenticationResponse = JsonSerializer.Deserialize<AuthenticationResponse>(responseContent);

        if (authenticationResponse is null)
        {
            throw new InvalidOperationException("Authentication failed.");
        }

        _currentToken = new Token(authenticationResponse.AccessToken, authenticationResponse.ExpiresIn);
    }

    protected async Task<T?> SendRequestAsync<T>(HttpRequestMessage request)
    {
        if (_currentToken is null ||
            _currentToken.IsExpired)
        {
            await AuthenticateAsync();
        }

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _currentToken!.Value);

        var response = await HttpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(responseContent);
    }
}
