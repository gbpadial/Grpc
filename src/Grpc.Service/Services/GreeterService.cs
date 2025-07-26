using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Grpc.Service.Services;

public class GreeterService : Greeter.GreeterBase
{
    [Authorize]
    public override Task<HelloReply> SayHelloAsync(HelloRequest request, ServerCallContext context)
    {
        var user = context.GetHttpContext().User;
        var userName = user.FindFirst(ClaimTypes.GivenName)?.Value;
        var userSurname = user.FindFirst(ClaimTypes.Surname)?.Value;

        var fullName = string.Join(' ', [userName, userSurname]).Trim();

        return Task.FromResult(new HelloReply
        {
            Message = $"Hello {fullName}".Trim()
        });
    }
}
