using CloudNativeKit.Abstractions.Domain;

namespace CloudNativeKit.Abstractions.Persistence.Mongo;

public interface IMongoRepository<TEntity, in TId> : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>;
