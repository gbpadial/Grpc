using Grpc.Client.Services;
using Grpc.Client.Setup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((ctx, services) =>
    {
        services
            .AddConfigurations()
            .AddHttpClients()
            .AddGrpcClients()
            .AddGrpcServices();
    })
    .Build();

var service = host.Services.GetRequiredService<IGrpcService>();

var result = await service.GetHelloAsync();

Console.WriteLine(result);
Console.ReadKey();