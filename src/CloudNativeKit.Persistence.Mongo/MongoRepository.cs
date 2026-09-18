using CloudNativeKit.Abstractions.Domain;
using Sieve.Services;

namespace CloudNativeKit.Persistence.Mongo;

public class MongoRepository<TDbContext, TEntity, TKey>(TDbContext dbContext, ISieveProcessor sieveProcessor)
    : MongoRepositoryBase<TDbContext, TEntity, TKey>(dbContext, sieveProcessor)
    where TEntity : class, IEntity<TKey>
    where TDbContext : MongoDbContext;

public class MongoRepository<TDbContext, TEntity>(TDbContext dbContext, ISieveProcessor sieveProcessor)
    : MongoRepository<TDbContext, TEntity, Guid>(dbContext, sieveProcessor)
    where TEntity : class, IEntity<Guid>
    where TDbContext : MongoDbContext;
