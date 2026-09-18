using CloudNativeKit.Abstractions.Queries;
using CloudNativeKit.Abstractions.Web.MinimalApi;
using Microsoft.AspNetCore.Http;

namespace CloudNativeKit.Web.Minimal;

public record HttpQuery(HttpContext HttpContext, IQueryBus QueryBus, CancellationToken CancellationToken) : IHttpQuery;
