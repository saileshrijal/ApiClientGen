# ApiClientGen
A .NET library for automatically generating API client code from OpenAPI (Swagger) or GraphQL schemas. ApiClientGen simplifies the integration of APIs by creating ready-to-use client libraries for .NET applications.

## Features
- Supports OpenAPI (Swagger) and GraphQL schemas
- Automatically generates C# client classes and methods
- Configurable output formats and customization options
- Lightweight, easy-to-use, and fully compatible with .NET Standard
- Handles asynchronous requests and error handling

## Installation
Coming soon on NuGet!

## Usage
```csharp
var generator = new ApiClientGenerator();
generator.GenerateFromOpenApi("https://example.com/swagger.json");
