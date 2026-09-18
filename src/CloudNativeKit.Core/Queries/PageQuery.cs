namespace CloudNativeKit.Core.Queries;

using CloudNativeKit.Abstractions.Queries;
using CloudNativeKit.Core.Paging;

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records#characteristics-of-records
public record PageQuery<TResponse> : PageRequest, IPageQuery<TResponse>
    where TResponse : notnull;
