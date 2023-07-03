using gRPC.Shared;
using ProtoBuf.Grpc;

namespace gRPC.Server;

public class TestService : ITestService
{
    public Task<Response> ProcessRequest(Request request, CallContext context = default)
    {
        return Task.FromResult(new Response() { Message = "test_message" });
    }
}