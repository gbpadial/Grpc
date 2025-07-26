using Grpc.Client.Configuration;
using Grpc.Client.Services;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Net;

namespace Grpc.Test.Grpc.Client.Services;

public class KeycloakServiceTest
{
    [Fact]
    public async Task GetKeycloakTokenAsync_ReturnsToken()
    {
        // Arrange
        var expectedToken = "test-token";
        var service = GetService(expectedToken);

        // Act
        var token = await service.GetKeycloakTokenAsync();

        // Assert
        Assert.Equal(expectedToken, token);
    }

    private static KeycloakService GetService(string token)
    {
        var messageHandler = new Mock<HttpMessageHandler>();
        messageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post && req.RequestUri == new Uri("https://test-server/realms/Padial/protocol/openid-connect/token")),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent($"{{\"access_token\":\"{token}\"}}")
            });

        var httpClientMock = new HttpClient(messageHandler.Object)
        {
            BaseAddress = new Uri("https://test-server/")
        };

        var optionsMock = new Mock<IOptions<KeycloakSettings>>();
        var settings = new KeycloakSettings
        {
            ClientId = "test-client",
            ClientSecret = "test-secret"
        };
        optionsMock.Setup(o => o.Value).Returns(settings);
        return new KeycloakService(httpClientMock, optionsMock.Object);
    }
}
