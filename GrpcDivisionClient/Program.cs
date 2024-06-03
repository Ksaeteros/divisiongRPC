using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcDivision;

namespace GrpcDivisionClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Cambiar a http en lugar de https
            var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new Division.DivisionClient(channel);

            // Solicitar la división
            try
            {
                var reply = await client.DivideAsync(new DivideRequest { Numerator = 20, Denominator = 2 });
                Console.WriteLine($"Resultado: {reply.Result}");
            }
            catch (Grpc.Core.RpcException ex)
            {
                Console.WriteLine($"Error: {ex.Status}");
            }
        }
    }
}
