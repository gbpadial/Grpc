# GRPC Solution

This repository contains a gRPC-based solution designed for building and consuming gRPC services. It is structured into multiple projects, each serving a specific purpose within the solution. Below is an overview of the solution's structure and functionality:

## Solution Structure

### `src/`
This directory contains the main source code for the solution, divided into the following projects:

- **Grpc.Client**: This project implements the gRPC client, which is responsible for consuming the gRPC services. It includes configuration files (`appsettings.json`), protocol buffer definitions (`Protos/`), and service setup logic (`Setup/`).

- **Grpc.Service**: This project implements the gRPC server, which provides the services consumed by the client. It includes configuration files (`appsettings.json`), protocol buffer definitions (`Protos/`), and service setup logic (`Setup/`).

### `test/`
This directory contains the test projects for the solution:

- **Grpc.Test**: This project includes unit tests and integration tests for the gRPC services and client. It ensures the reliability and correctness of the solution.

### `.vs/`
This directory contains Visual Studio-specific files and configurations, such as build cache and metadata.

## Key Features

- **gRPC Communication**: The solution leverages gRPC for efficient and scalable communication between the client and server.
- **Protocol Buffers**: Protocol buffer files (`Protos/`) define the structure of the messages exchanged between the client and server.
- **Authentication with Keycloak**: The gRPC calls are secured using authentication mechanisms provided by Keycloak. This ensures that only authorized clients can access the services.
- **Configuration Management**: Each project includes configuration files (`appsettings.json`) for managing environment-specific settings.

## How to Build and Run

1. Open the solution file (`Grpc.sln`) in Visual Studio.
2. Build the solution to restore dependencies and compile the projects.
3. Run the `Grpc.Service` project to start the gRPC server.
4. Run the `Grpc.Client` project to consume the services provided by the server.

## Testing

To run tests, open the `test.sln` file in Visual Studio and execute the tests in the `Grpc.Test` project.

## Dependencies

- .NET Core or .NET Framework (depending on the target framework specified in the project files).
- gRPC and Protocol Buffers libraries.
- Keycloak for authentication.

## License

## License

MIT License

Copyright (c) [Year] [Your Name or Organization]

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.