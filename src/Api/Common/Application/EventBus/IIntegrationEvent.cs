namespace Application.EventBus;

/// <summary>
/// Represents the integration event interface.
/// </summary>
public interface IIntegrationEvent
{
    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public DefaultIdType Id { get; }

    /// <summary>
    /// Gets the occurred on date and time.
    /// </summary>
    public DateTime OccurredOnUtc { get; }
}