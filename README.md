# CloudNativeKit

Reusable .NET building blocks for cloud-native applications and microservices.

CloudNativeKit packages common service infrastructure behind small, composable registration methods. Use only the capabilities your service needs: web conventions, messaging, persistence, observability, security, resilience, validation, caching, and local infrastructure through .NET Aspire.

All packages target `net10.0`, use the `CloudNativeKit.*` namespace and package family, and are versioned together.

## Package map

| Area                            | Packages                                                                                                                                                                                                                                                               |
| ------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Foundations                     | `CloudNativeKit.Abstractions`, `CloudNativeKit.Core`                                                                                                                                                                                                                   |
| Web and platform                | `CloudNativeKit.Web`, `CloudNativeKit.Security`, `CloudNativeKit.HealthCheck`, `CloudNativeKit.Resiliency`, `CloudNativeKit.Email`                                                                                                                                     |
| Messaging                       | `CloudNativeKit.Integration.Wolverine`                                                                                                                                                                                                                                 |
| Persistence                     | `CloudNativeKit.Persistence.EfCore.Postgres`, `CloudNativeKit.Persistence.EfCore.AzurePostgres`, `CloudNativeKit.Persistence.EfCore.AzureCosmosDB`, `CloudNativeKit.Persistence.Mongo`, `CloudNativeKit.Persistence.Marten`, `CloudNativeKit.Persistence.EventStoreDB` |
| Observability and API contracts | `CloudNativeKit.OpenTelemetry`, `CloudNativeKit.OpenApi`, `CloudNativeKit.SerilogLogging`                                                                                                                                                                              |
| Supporting infrastructure       | `CloudNativeKit.Caching`, `CloudNativeKit.Caching.AzureRedis`, `CloudNativeKit.Serialization`, `CloudNativeKit.Validation`, `CloudNativeKit.AspireIntegrations`                                                                                                        |

See the [package reference](docs/reference/packages.md) and [component documentation](docs/components/) for package-specific setup, configuration, and examples.

## Typical service setup

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.AddCoreServices();
builder.AddCustomResiliency();
builder.AddDefaultOpenTelemetry();
builder.AddDefaultHealthChecks();
builder.AddCustomProblemDetails(new[] { typeof(Program).Assembly });
builder.Services.AddCustomValidators(typeof(Program).Assembly);

var app = builder.Build();
app.MapDefaultHealthChecks();
app.Run();
```

Add persistence and messaging registrations only when the service uses those capabilities. CloudNativeKit reads connection strings from standard .NET configuration and supports Aspire-injected connection strings.

## Install

```bash
dotnet add package CloudNativeKit.Core
dotnet add package CloudNativeKit.Web
dotnet add package CloudNativeKit.OpenTelemetry
```

Package versions are released together and follow the repository version calculated by Nerdbank.GitVersioning.

## Build

```bash
dotnet build src/CloudNativeKit.Abstractions/CloudNativeKit.Abstractions.csproj -c Release -p:SkipVersion=true
```

## Pack

```bash
dotnet pack src/CloudNativeKit.Abstractions/CloudNativeKit.Abstractions.csproj -c Release -p:SkipVersion=true
```

## Tests

```bash
dotnet build tests/Shared/Tests.Shared/Tests.Shared.csproj -c Release -p:SkipVersion=true -p:RunAnalyzers=false
dotnet test --project tests/CloudNativeKit.Core/CloudNativeKit.Core.UnitTests/CloudNativeKit.Core.UnitTests.csproj -c Release -p:SkipVersion=true
```
