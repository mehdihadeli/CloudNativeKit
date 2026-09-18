# Quickstart

## Requirements

- .NET SDK 10
- A .NET application using Microsoft.Extensions hosting and dependency injection
- NuGet access to the CloudNativeKit packages

## Install a package

Start with the foundation package, then add the packages that own the capabilities used by your service:

```bash
dotnet add package CloudNativeKit.Core
dotnet add package CloudNativeKit.Web
dotnet add package CloudNativeKit.OpenTelemetry
dotnet add package CloudNativeKit.HealthCheck
```

For example, persistence integrations are separate packages:

```bash
dotnet add package CloudNativeKit.Persistence.Marten
dotnet add package CloudNativeKit.Persistence.EventStoreDB
```

## Register common services

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.AddCoreServices();
builder.AddCustomResiliency();
builder.AddDefaultOpenTelemetry();
builder.AddDefaultHealthChecks();
builder.AddCustomProblemDetails(new[] { typeof(Program).Assembly });

var app = builder.Build();
app.MapDefaultHealthChecks();
app.Run();
```

Continue with the [package reference](../reference/packages) to choose a persistence, messaging, security, or local infrastructure adapter.

Package versions are released together and follow the repository version calculated by Nerdbank.GitVersioning.

## Build from source

```bash
git clone https://github.com/mehdihadeli/CloudNativeKit.git
cd CloudNativeKit
dotnet build src/CloudNativeKit.Core/CloudNativeKit.Core.csproj -c Release
```

Run the existing test projects with:

```bash
dotnet build tests/CloudNativeKit.Core/CloudNativeKit.Core.UnitTests/CloudNativeKit.Core.UnitTests.csproj -c Release
```

Every component has an empty `UnitTests` and `IntegrationTests` project ready for future coverage.
