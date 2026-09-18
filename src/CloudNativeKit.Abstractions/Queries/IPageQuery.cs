using CloudNativeKit.Abstractions.Core.Paging;

namespace CloudNativeKit.Abstractions.Queries;

public interface IPageQuery<out TResponse> : IPageRequest, IQuery<TResponse>
    where TResponse : notnull;
