# CloudNativeKit.Caching

Hybrid caching behaviors and Redis publish/subscribe contracts for application services.

## Install

```bash
dotnet add package CloudNativeKit.Caching
```

## Register

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.AddCustomCaching();
```

Configure the cache implementation through the application configuration and add `CloudNativeKit.Caching.AzureRedis` when Redis-backed caching is required.

## Use it when

Use `ICacheQuery<TRequest, TResponse>` for cacheable queries and `IInvalidateCacheRequest<TRequest, TResponse>` when a command must invalidate related entries. Use `IRedisPubSubService` for Redis pub/sub integration.
