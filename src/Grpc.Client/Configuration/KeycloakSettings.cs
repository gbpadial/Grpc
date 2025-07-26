﻿namespace Grpc.Client.Configuration;

public class KeycloakSettings
{
    public string BaseUrl { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}
