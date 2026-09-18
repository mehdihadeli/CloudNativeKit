using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CloudNativeKit.Abstractions.Persistence;

public interface IDbFacadeResolver
{
    DatabaseFacade Database { get; }
}
