namespace CloudNativeKit.Core.Messages;

using CloudNativeKit.Abstractions.Messages;

public abstract record IntegrationEvent : Message, IIntegrationEvent;
