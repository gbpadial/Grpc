using Grpc.Client.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Grpc.Client.Services;

public interface IKeycloakService
{
    Task<string> GetKeycloakTokenAsync();
}

public class KeycloakService(HttpClient client, IOptions<KeycloakSettings> options) : IKeycloakService
{
    private readonly KeycloakSettings _settings = options.Value;

    public async Task<string> GetKeycloakTokenAsync()
    {
        const string TokenPath = "realms/Padial/protocol/openid-connect/token";
        var parameters = new Dictionary<string, string>
        {
            { "client_id", _settings.ClientId },
            { "client_secret", _settings.ClientSecret },
            { "grant_type", "client_credentials" },
            { "scope" , "openid profile" }
        };

        var content = new FormUrlEncodedContent(parameters);

        var response = await client.PostAsync(TokenPath, content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var token = JsonDocument.Parse(json).RootElement.GetProperty("access_token").GetString();

        return token!;
    }
}
