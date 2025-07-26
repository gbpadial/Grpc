using Grpc.Core;
using Grpc.Core.Testing;
using Grpc.Service;
using Grpc.Service.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Grpc.Test.Grpc.Service.Services;

public class GreeterServiceTest
{
    [Theory]
    [InlineData("John", "", " John")]
    [InlineData("John", "Doe", " John Doe")]
    [InlineData("", "Doe", " Doe")]
    [InlineData("", "", "")]
    public async Task SayHelloAsync_WithRequest_ShouldReturnHelloMessage(
        string name,
        string surname,
        string expected)
    {
        // Arrange
        var claims = new List<Claim>
        {
            new(ClaimTypes.GivenName, name),
            new(ClaimTypes.Surname, surname)
        };
        var identity = new ClaimsIdentity(claims, "TestAuthType");
        var principal = new ClaimsPrincipal(identity);

        var httpContext = new DefaultHttpContext()
        {
            User = principal
        };

        var context = TestServerCallContext.Create(
            method: "TestMethod",
            host: "localhost",
            deadline: DateTime.UtcNow.AddMinutes(1),
            requestHeaders: [],
            cancellationToken: CancellationToken.None,
            peer: "127.0.0.1",
            authContext: null,
            contextPropagationToken: null,
            writeHeadersFunc: metadata => Task.CompletedTask,
            writeOptionsGetter: () => new WriteOptions(),
            writeOptionsSetter: options => { }
        );
        context.UserState["__HttpContext"] = httpContext;

        var greeterService = new GreeterService();
        var request = new HelloRequest();

        // Act
        var response = await greeterService.SayHelloAsync(request, context);

        // Assert
        Assert.Equal($"Hello{expected}", response.Message);
    }
}
