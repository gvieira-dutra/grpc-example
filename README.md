# Recipe Manager API that leverages .NET 8, gRPC, PostgreSQL and Aspire
This repository aims to demonstrate how API's can leverage the gRPC library to communicate with microservices. 
It also show how multiple projects can be orchestrated by the .NET Aspire. As database, I make use of Marten to manage PostgreSQL database.

## Table of Contents
- [Architecture Overview](#architecture-overview)
- [Features](#features) 
- [Getting Started](#getting-started)
- [License](#license)

## Architecture Overview

This project follows the Vertical Slice Architecture principles, organizing code by feature to improve modularity and maintainability. Each feature contains its own logic, data access, and operations, allowing for independent development and testing. This structure reduces cross-feature dependencies, making the application easier to scale and modify.
  
## Features

- **.NET 8 Framework**: Core framework for building high-performance applications.
- **.NET Aspire**: Orchestrates cloud-native applications, managing services and resources.
- **gRPC**: Protocol for fast communication between APIs and microservices.
- **Marten**: Data management library for PostgreSQL in .NET applications.
- **PostgreSQL**: Powerful relational database for structured data.
- **Entity Framework Core**: ORM framework that streamlines database interactions.

## Getting Started

To get a local copy of this project, follow these steps:

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Docker

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/gvieira-dutra/grpc-example.git
   ```
2. Navigate into the project directory
   ```sh
   cd grpc-example
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```

## License

Distributed under the MIT License. See `LICENSE` for more information.
