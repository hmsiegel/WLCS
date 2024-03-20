namespace Domain.Primitives;

/// <summary>
/// Represents the abstract domain event primitive.
/// </summary>
public abstract record DomainEvent : IDomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="occurredOnUtc">The occurred on date and time.</param>
    protected DomainEvent(DefaultIdType id, DateTime occurredOnUtc)
        : this()
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class.
    /// </summary>
    private DomainEvent()
    {
    }

    /// <inheritdoc/>
    public DefaultIdType Id { get; }

    /// <inheritdoc/>
    public DateTime OccurredOnUtc { get; }
}
