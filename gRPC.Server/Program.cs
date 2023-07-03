using gRPC.Server;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCodeFirstGrpc();

var app = builder.Build();

app.MapGrpcService<TestService>();

app.MapGet("/", () => "Hello World!");

app.Run();