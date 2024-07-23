using Logto.WebApi.Sdk.Common;
using Logto.WebApi.Sdk.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Logto.WebApi.Sdk;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLotgoApi(
            this IServiceCollection services,
            IConfiguration configuration,
            string sectionName = "LogtoApi")
    {
        services.Configure<LogtoEndpoint>(configuration.GetSection(sectionName));
        services.PostConfigure<LogtoEndpoint>(opt =>
        {
            if (string.IsNullOrWhiteSpace(opt.Url))
            {
                throw new KeyNotFoundException("Logto API configuration: missing URL.");
            }
            if (string.IsNullOrWhiteSpace(opt.ClientId))
            {
                throw new KeyNotFoundException("Logto API configuration: missing client id.");
            }
            if (string.IsNullOrWhiteSpace(opt.ClientSecret))
            {
                throw new KeyNotFoundException("Logto API configuration: missing client secret.");
            }
        });

        services.AddHttpClient<LogtoUsersClient>((serviceProvider, client) =>
        {
            var wisemblyEndpoint = serviceProvider
                .GetRequiredService<IOptions<LogtoEndpoint>>().Value;

            client.BaseAddress = new Uri(wisemblyEndpoint.Url);
        });

        return services;
    }
}
