using CloudNativeKit.Abstractions.Commands;
using CloudNativeKit.Abstractions.Web.MinimalApi;
using Microsoft.AspNetCore.Http;

namespace CloudNativeKit.Web.Minimal;

public record HttpCommand<TRequest>(
    TRequest Request,
    HttpContext HttpContext,
    ICommandBus CommandBus,
    CancellationToken CancellationToken
) : IHttpCommand<TRequest>;
