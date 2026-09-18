using CloudNativeKit.Abstractions.Persistence;
using Mediator;

namespace CloudNativeKit.Abstractions.Commands;

public interface ITxCommand : ITxCommand<Unit>;

public interface ITxCommand<out T> : ICommand<T>, ITxRequest
    where T : notnull;
