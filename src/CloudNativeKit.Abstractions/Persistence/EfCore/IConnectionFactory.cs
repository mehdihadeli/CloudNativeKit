using System.Data.Common;

namespace CloudNativeKit.Abstractions.Persistence.EfCore;

public interface IConnectionFactory : IDisposable
{
    Task<DbConnection> GetOrCreateConnectionAsync();
}
