using Grpc.Client.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Grpc.Client.Setup;

[ExcludeFromCodeCoverage]
public static class ConfigurationInstaller
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Program>()
            .Build();

        return services
            .AddSingleton<IConfiguration>(configuration)
            .Configure<KeycloakSettings>(configuration.GetSection(nameof(KeycloakSettings)));
    }
}
