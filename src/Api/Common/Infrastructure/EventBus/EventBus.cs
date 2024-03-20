namespace Infrastructure.EventBus;

/// <summary>
/// Represents the event bus.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="EventBus"/> class.
/// </remarks>
/// <param name="bus">The bus.</param>
public sealed class EventBus(IBus bus) : IEventBus, ITransient
{
    /// <inheritdoc />
    public async Task PublishAsync<TIntegrationEvent>(TIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
        where TIntegrationEvent : IIntegrationEvent =>
        await bus.Publish(integrationEvent, cancellationToken).ConfigureAwait(false);
}