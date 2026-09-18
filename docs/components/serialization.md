# CloudNativeKit.Serialization

Message serialization registration for MemoryPack-based application messaging.

## Install

```bash
dotnet add package CloudNativeKit.Serialization
```

## Register

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryPackSerialization();
```

Use the serialization contracts from `CloudNativeKit.Abstractions` in messages shared between services. Add generated or explicitly registered MemoryPack formatters for custom types.
