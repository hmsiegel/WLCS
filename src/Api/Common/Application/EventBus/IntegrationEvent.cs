namespace Application.EventBus;

/// <summary>
/// Represents the abstract integration event primitive.
/// </summary>
public abstract record IntegrationEvent(DefaultIdType Id, DateTime OccurredOnUtc) : IIntegrationEvent;
