# Packages

CloudNativeKit publishes a coordinated `CloudNativeKit.*` NuGet family. Install only the packages needed by each service; package registrations are designed to compose through `IHostApplicationBuilder` and `IServiceCollection`.

## Foundations

| Package                       | Purpose                                                                           | Details                                                |
| ----------------------------- | --------------------------------------------------------------------------------- | ------------------------------------------------------ |
| `CloudNativeKit.Abstractions` | Shared contracts for commands, queries, events, persistence, paging, and modules. | [Read the component guide](../components/abstractions) |
| `CloudNativeKit.Core`         | Core buses, domain services, options, exceptions, and common extensions.          | [Read the component guide](../components/core)         |

## Platform

| Package                      | Purpose                                                                          | Details                                                |
| ---------------------------- | -------------------------------------------------------------------------------- | ------------------------------------------------------ |
| `CloudNativeKit.Web`         | CORS, compression, versioning, rate limiting, problem details, and minimal APIs. | [Read the component guide](../components/web)          |
| `CloudNativeKit.Security`    | JWT and API-key authentication helpers.                                          | [Read the component guide](../components/security)     |
| `CloudNativeKit.HealthCheck` | Default liveness and readiness health checks.                                    | [Read the component guide](../components/health-check) |
| `CloudNativeKit.Resiliency`  | Service discovery and HTTP resilience defaults.                                  | [Read the component guide](../components/resiliency)   |
| `CloudNativeKit.Email`       | Email delivery abstraction and provider integration.                             | [Read the component guide](../components/email)        |

## Messaging and persistence

| Package                                           | Purpose                                                                  | Details                                                                     |
| ------------------------------------------------- | ------------------------------------------------------------------------ | --------------------------------------------------------------------------- |
| `CloudNativeKit.Integration.Wolverine`            | Wolverine and RabbitMQ event bus integration.                            | [Read the component guide](../components/wolverine)                         |
| `CloudNativeKit.Persistence.EfCore.Postgres`      | PostgreSQL EF Core context, repositories, unit of work, and migrations.  | [Read the component guide](../components/persistence-efcore-postgres)       |
| `CloudNativeKit.Persistence.EfCore.AzurePostgres` | Azure PostgreSQL package area.                                           | [Read the component guide](../components/persistence-efcore-azure-postgres) |
| `CloudNativeKit.Persistence.EfCore.AzureCosmosDB` | Azure Cosmos DB persistence package area.                                | [Read the component guide](../components/persistence-efcore-azure-cosmosdb) |
| `CloudNativeKit.Persistence.Mongo`                | MongoDB context, repositories, unit of work, tracing, and health checks. | [Read the component guide](../components/persistence-mongo)                 |
| `CloudNativeKit.Persistence.Marten`               | Marten document and event-sourcing integration.                          | [Read the component guide](../components/persistence-marten)                |
| `CloudNativeKit.Persistence.EventStoreDB`         | EventStoreDB client and event-sourcing integration.                      | [Read the component guide](../components/persistence-eventstoredb)          |

## Observability and supporting infrastructure

| Package                             | Purpose                                                   | Details                                                       |
| ----------------------------------- | --------------------------------------------------------- | ------------------------------------------------------------- |
| `CloudNativeKit.OpenTelemetry`      | OpenTelemetry traces, metrics, logs, and instrumentation. | [Read the component guide](../components/opentelemetry)       |
| `CloudNativeKit.OpenApi`            | Swagger, ASP.NET OpenAPI, API versioning, and AsyncAPI.   | [Read the component guide](../components/openapi)             |
| `CloudNativeKit.SerilogLogging`     | Structured logging and request enrichment.                | [Read the component guide](../components/serilog-logging)     |
| `CloudNativeKit.Caching`            | Cache abstractions and cache registration.                | [Read the component guide](../components/caching)             |
| `CloudNativeKit.Caching.AzureRedis` | Azure Redis cache integration.                            | [Read the component guide](../components/caching-azure-redis) |
| `CloudNativeKit.Serialization`      | MemoryPack serialization registration.                    | [Read the component guide](../components/serialization)       |
| `CloudNativeKit.Validation`         | FluentValidation assembly scanning.                       | [Read the component guide](../components/validation)          |
| `CloudNativeKit.AspireIntegrations` | .NET Aspire resources for local infrastructure.           | [Read the component guide](../components/aspire-integrations) |

All packages target `net10.0` and are versioned together with Nerdbank.GitVersioning.
