using Grpc.Core;

namespace Grpc.Test.Grpc.Client.Mocks;

public static class GrpcMockHelper
{
    public static AsyncUnaryCall<TResponse> CreateMockUnaryCall<TResponse>(TResponse response) => new
    (
        Task.FromResult(response),
        Task.FromResult(new Metadata()),
        () => Status.DefaultSuccess,
        () => new Metadata(),
        () => { }
    );
}
