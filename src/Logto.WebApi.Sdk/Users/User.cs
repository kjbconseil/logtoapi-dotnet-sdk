using System.Text.Json.Serialization;

namespace Logto.WebApi.Sdk.Users;

#pragma warning disable CS1591

public class User
{
    /// <summary>
    /// The unique identifier of the user.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [JsonPropertyName("primaryEmail")]
    public string PrimaryEmail { get; set; } = null!;

    [JsonPropertyName("primaryPhone")]
    public string? PrimaryPhone { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    [JsonPropertyName("identities")]
    public Identities? Identities { get; set; }

    [JsonPropertyName("lastSignInAt")]
    public double? LastSignInAt { get; set; }

    [JsonPropertyName("createdAt")]
    public double? CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public double? UpdatedAt { get; set; }

    [JsonPropertyName("profile")]
    public Profile Profile { get; set; } = null!;

    [JsonPropertyName("applicationId")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("isSuspended")]
    public bool? IsSuspended { get; set; }

    [JsonPropertyName("hasPassword")]
    public bool? HasPassword { get; set; }

    [JsonPropertyName("ssoIdentities")]
    public List<SsoIdentity> SsoIdentities { get; set; } = [];
}

public class Address
{
    [JsonPropertyName("formatted")]
    public string? Formatted { get; set; }

    [JsonPropertyName("streetAddress")]
    public string? StreetAddress { get; set; }

    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }
}

public class Identities
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = null!;
}

public class Profile
{
    [JsonPropertyName("familyName")]
    public string? FamilyName { get; set; }

    [JsonPropertyName("givenName")]
    public string? GivenName { get; set; }

    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }

    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    [JsonPropertyName("preferredUsername")]
    public string? PreferredUsername { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("birthdate")]
    public string? Birthdate { get; set; }

    [JsonPropertyName("zoneinfo")]
    public string? Zoneinfo { get; set; }

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    [JsonPropertyName("address")]
    public Address? Address { get; set; }
}

public class SsoIdentity
{
    [JsonPropertyName("tenantId")]
    public string TenantId { get; set; } = null!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("userId")]
    public string UserId { get; set; } = null!;

    [JsonPropertyName("issuer")]
    public string Issuer { get; set; } = null!;

    [JsonPropertyName("identityId")]
    public string IdentityId { get; set; } = null!;

    [JsonPropertyName("createdAt")]
    public double? CreatedAt { get; set; } = null!;

    [JsonPropertyName("ssoConnectorId")]
    public string SsoConnectorId { get; set; } = null!;
}
