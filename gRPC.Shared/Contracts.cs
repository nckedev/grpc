using System.Runtime.Serialization;
using System.ServiceModel;
using ProtoBuf.Grpc;

namespace gRPC.Shared;

[DataContract]
public class Request
{
    [DataMember(Order = 1)]
    public string Id { get; set; }
}

[DataContract]
public class Response
{
    [DataMember(Order = 1)]
    public string Message { get; set; }
}

[ServiceContract]
public interface ITestService
{
    [OperationContract]
    Task<Response> ProcessRequest(Request request, CallContext context = default);
}