using System.Text.Json.Serialization;

namespace Logto.WebApi.Sdk.Authentication;

public class AuthenticationRequest
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; } = null!;

    /// <summary>
    /// In seconds.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = null!;

    [JsonPropertyName("scope")]
    public string Scope { get; set; } = null!;
}
