// The server is running on localhost at port 5001 (default for HTTPS)

using Grpc.Net.Client;
using GrpcAddClient;

using var channel = GrpcChannel.ForAddress("https://localhost:7198");
var client = new CalculatorGrpc.CalculatorGrpcClient(channel);

// Send the Add request
Console.Write("Enter 1st Number:");
var number1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter 2nd Number:");
var number2 = Convert.ToInt32 (Console.ReadLine());

var response = await client.AddAsync(new AddRequest { Number1 = number1, Number2 = number2 });

// Display the result
Console.WriteLine("Hello, Successfully access gRPC service!!!");
Console.WriteLine($"Result of {number1} + {number2} = {response.Result}");
Console.ReadLine();
