using Grpc.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Grpc.Client.Setup;

[ExcludeFromCodeCoverage]
public static class GrpcClientInstaller
{
    public static IServiceCollection AddGrpcClients(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IConfiguration>();

        services.AddGrpcClient<Greeter.GreeterClient>(options =>
        {
            var baseUrl = configuration["GrpcServiceBaseUrl"]
                ?? throw new ArgumentException("GrpcServiceBaseUrl not informed");

            options.Address = new Uri(baseUrl);
        })
        .AddCallCredentials(async (context, metadata, serviceProvider) =>
        {
            var keycloakService = serviceProvider.GetRequiredService<IKeycloakService>();
            var token = await keycloakService.GetKeycloakTokenAsync();
            metadata.Add("Authorization", $"Bearer {token}");
        });

        return services;
    }
}
