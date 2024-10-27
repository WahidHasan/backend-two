**GrpcAddService**

GrpcAddService is a basic gRPC project built in .NET that consists of a gRPC server (service) and a console client. The client connects to the server to perform a simple addition operation remotely via gRPC.

**Project Overview**
GrpcAddService: This is the gRPC server, hosting the CalculatorGrpc service, which provides an Add method.
GrpcAddClient: This is a console application that acts as a gRPC client, requesting addition operations from the GrpcAddService server.

**Requirements**
Before running this project, make sure you have:

.NET SDK 6.0 or later - Required to build and run the project. Download .NET SDK
Visual Studio - Recommended IDE for managing and running multiple projects in a solution. You can also use Visual Studio Code.

**Build the Solution**
After navigating to the project directory, use the following command to build the entire solution:
dotnet build

**Project Structure**
* GrpcAddService.csproj: The gRPC server project file.
* GrpcAddClient.csproj: The console client project file.
* Protos/calculator.proto: The protocol buffer file that defines the gRPC service and messages.

**Proto File Details**
syntax = "proto3";
option csharp_namespace = "GrpcAddService";

package calculator;

service CalculatorGrpc {
  rpc Add (AddRequest) returns (AddResponse);
}

message AddRequest {
  int32 number1 = 1;
  int32 number2 = 2;
}

message AddResponse {
  int32 result = 1;
}

**Running the Project**
  - Configure Multiple Startup Projects in Visual Studio
  - Right-click on the Solution in Solution Explorer, then select Properties.
  - Go to Startup Project and select Multiple Startup Projects.
  - Set the action to Start for both GrpcAddService and GrpcAddClient.
  - Ensure GrpcAddService is the first project to start (order matters to ensure the server is up before the client tries to connect).
  - Click Apply and OK.


