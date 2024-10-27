using Grpc.Core;

namespace GrpcAddService.Services
{
    public class CalculatorService : CalculatorGrpc.CalculatorGrpcBase
    {
        public override Task<AddResponse> Add(AddRequest request, ServerCallContext context)
        {
            int result = request.Number1 + request.Number2;
            return Task.FromResult(new AddResponse
            {
                Result = result
            });
        }
    }
}
