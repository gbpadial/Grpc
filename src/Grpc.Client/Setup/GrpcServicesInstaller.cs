using Grpc.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Grpc.Client.Setup;

[ExcludeFromCodeCoverage]
public static class GrpcServicesInstaller
{
    public static IServiceCollection AddGrpcServices(this IServiceCollection services)
        => services.AddScoped<IGrpcService, GrpcService>();
}
