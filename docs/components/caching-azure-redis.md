# CloudNativeKit.Caching.AzureRedis

Azure Redis connection and cache integration for CloudNativeKit caching.

## Install

```bash
dotnet add package CloudNativeKit.Caching.AzureRedis
```

## Use it with

Install this package together with `CloudNativeKit.Caching`. Configure the Redis connection using the options expected by the package, then call the shared caching registration from `CloudNativeKit.Caching`.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.AddCustomCaching();
```

Keep provider-specific configuration in the service's configuration system so local development can use a local Redis instance and deployed environments can use Azure Managed Redis.
