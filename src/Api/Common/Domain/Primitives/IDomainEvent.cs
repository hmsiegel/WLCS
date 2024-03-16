namespace Domain.Primitives;

/// <summary>
/// Represents the domain event interface.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the identifier.
    /// </summary>
    DefaultIdType Id { get; }

    /// <summary>
    /// Gets the occurred on date and time.
    /// </summary>
    DateTime OccurredOnUtc { get; }
}
