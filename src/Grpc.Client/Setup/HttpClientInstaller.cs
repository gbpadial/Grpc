using Grpc.Client.Configuration;
using Grpc.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace Grpc.Client.Setup;

[ExcludeFromCodeCoverage]
public static class HttpClientInstaller
{
    public static IServiceCollection AddHttpClients(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var settings = provider.GetRequiredService<IOptions<KeycloakSettings>>();

        services.AddHttpClient<IKeycloakService, KeycloakService>(client =>
            {
                client.BaseAddress = new Uri(settings.Value.BaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

        return services;
    }
}
