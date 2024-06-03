using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcDivision
{
    public class DivisionService : Division.DivisionBase
    {
        private readonly ILogger<DivisionService> _logger;
        public DivisionService(ILogger<DivisionService> logger)
        {
            _logger = logger;
        }

        public override Task<DivideReply> Divide(DivideRequest request, ServerCallContext context)
        {
            double result = request.Numerator / request.Denominator;
            return Task.FromResult(new DivideReply
            {
                Result = result
            });
        }
    }
}
