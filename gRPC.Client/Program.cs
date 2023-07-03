// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using gRPC.Shared;
using ProtoBuf.Grpc.Client;

// AppContext.SetSwitch(
//     "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
using var channel = GrpcChannel.ForAddress("https://localhost:7143");
var client = channel.CreateGrpcService<ITestService>();

var response = await client.ProcessRequest(new Request() { Id = "1" });
Console.WriteLine(response.Message);