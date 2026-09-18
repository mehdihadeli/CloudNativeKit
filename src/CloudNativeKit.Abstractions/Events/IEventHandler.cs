using Mediator;

namespace CloudNativeKit.Abstractions.Events;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification;
