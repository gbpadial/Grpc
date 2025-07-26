using Grpc.Service.Services;
using Grpc.Service.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .InstallAuthentication(builder.Configuration)
    .AddGrpc();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();
