using Logto.WebApi.Sdk.Common;
using Logto.WebApi.Sdk.Users;
using Microsoft.Extensions.Options;

namespace Logto.WebApi.Sdk.Tests.Authentication;

[Trait("Category", "Users")]
public class GetUsersTests
{
    [Fact]
    public async Task MustSuccess()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("")
        };
        var usersClient = new LogtoUsersClient(httpClient, Options.Create(new LogtoEndpoint()
        {
            Url = "",
            ClientId = "",
            ClientSecret = ""
        }));

        var users = await usersClient.GetUsersAsync();

        Assert.NotNull(users);
        Assert.NotEmpty(users);
        Assert.NotEmpty(users.First().Username);
    }
}
