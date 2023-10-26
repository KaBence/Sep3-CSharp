using Grpc.Core;
using Sep3;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;


namespace WebApi;

public class Service : Sep3.ProofService.ProofServiceBase
{
    private readonly ILogger<Service> _logger;
    public Service(ILogger<Service> logger)
    {
        _logger = logger;
    }
 


    public override Task<putStringRes> putString(putStringReq request, ServerCallContext context)
    {
        return Task.FromResult(new putStringRes
        {
            Resp = context.Status.Detail
        });
    }
}