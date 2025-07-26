namespace Grpc.Client.Services;

public interface IGrpcService
{
    Task<string> GetHelloAsync(CancellationToken cancellationToken = default);
}

public class GrpcService(Greeter.GreeterClient client) : IGrpcService
{
    public async Task<string> GetHelloAsync(CancellationToken cancellationToken = default)
    {
        var reply = await client.SayHelloAsync(new HelloRequest(), cancellationToken: cancellationToken);
        return "Greeting: " + reply.Message;
    }
}
