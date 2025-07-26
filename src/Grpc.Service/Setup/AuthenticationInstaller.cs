using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Diagnostics.CodeAnalysis;

namespace Grpc.Service.Setup;

[ExcludeFromCodeCoverage]
public static class AuthenticationInstaller
{
    public static IServiceCollection InstallAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var authority = configuration["KeycloakSettings:Authority"]
            ?? throw new ArgumentException("KeycloakSettings:Authority was not informed");

        var audience = configuration["KeycloakSettings:Audience"]
            ?? throw new ArgumentException("KeycloakSettings:Audience was not informed");

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer((options) =>
            {
                options.Authority = authority;
                options.Audience = audience;
                options.RequireHttpsMetadata = false;
            });

        services.AddAuthorization();

        return services;
    }
}
