using Grpc.Client;
using Grpc.Client.Services;
using Grpc.Core;
using Grpc.Test.Grpc.Client.Mocks;
using Moq;

namespace Grpc.Test.Grpc.Client.Services;

public class GrpcServiceTest
{
    [Fact]
    public async Task GetHelloAsync_WhenCalled_ReturnsGreeting()
    {
        // Arrange
        var grpcService = GetService();

        // Act
        var result = await grpcService.GetHelloAsync();

        // Assert
        Assert.Equal("Greeting: Hello, World!", result);
    }

    private static GrpcService GetService(string message = "Hello, World!")
    {
        var mockClient = new Mock<Greeter.GreeterClient>();
        var mockCall = GrpcMockHelper.CreateMockUnaryCall(new HelloReply { Message = message });

        mockClient
            .Setup(client => client.SayHelloAsync(
                It.IsAny<HelloRequest>(),
                It.IsAny<Metadata>(),
                It.IsAny<DateTime?>(),
                It.IsAny<CancellationToken>()))
            .Returns(mockCall);

        return new GrpcService(mockClient.Object);
    }
}
