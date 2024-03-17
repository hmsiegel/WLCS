namespace Infrastructure.Utilities;

/// <summary>
/// Represents the event handlers utility class.
/// </summary>
public static class EventHandlersUtility
{
    private static readonly Type _notificationEventHandlerType = typeof(INotificationHandler<>);

    private static readonly Type _domainEventHandlerType = typeof(IDomainEventHandler<>);

    private static readonly Type _integrationEventHandlerType = typeof(IIntegrationEventHandler<>);

    /// <summary>
    /// Checks if the speficied type implements the <see cref="IDomainEventHandler{TEvent}"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True if the specified type implements the <see cref="IDomainEventHandler{TEvent}"/>, otherwise false.</returns>
    public static bool ImplementsDomainEventHandler(Type type)
    {
        if (type is null)
        {
            ArgumentNullException.ThrowIfNull(type);
        }

        return type.GetInterfaces().Length != 0 &&
            type.GetInterfaces().All(interfaceType => IsNotificationHandler(interfaceType) || IsDomainEventHandler(interfaceType));
    }

    /// <summary>
    /// Checks if the speficied type implements the <see cref="IIntegrationEventHandler{TEvent}"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True if the specified type implements the <see cref="IIntegrationEventHandler{TEvent}"/>, otherwise false.</returns>
    public static bool ImplementsIntegrationEventHandler(Type type)
    {
        if (type is null)
        {
            ArgumentNullException.ThrowIfNull(type);
        }

        return type.GetInterfaces().Any(IsDomainEventHandler);
    }

    /// <summary>
    /// Checks if the specified type inherits from <see cref="INotificationHandler{TNotification}"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True is the specified type inherits from <see cref="INotificationHandler{TNotification}"/>, otherwise false.</returns>
    private static bool IsNotificationHandler(Type type) =>
        type.IsGenericType &&
        type.Name.StartsWith(_notificationEventHandlerType.Name, StringComparison.InvariantCulture);

    /// <summary>
    /// Checks if the specified type inherits from <see cref="IDomainEventHandler{TEvent}"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True is the specified type inherits from <see cref="IDomainEventHandler{TEvent}"/>, otherwise false.</returns>
    private static bool IsDomainEventHandler(Type type) =>
        type.IsGenericType &&
        type.Name.StartsWith(_domainEventHandlerType.Name, StringComparison.InvariantCulture);

    /// <summary>
    /// Checks if the specified type inherits from <see cref="IIntegrationEventHandler{TIntegrationEvent}"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True is the specified type inherits from <see cref="IIntegrationEventHandler{TIntegrationEvent}"/>, otherwise false.</returns>
    private static bool IsIntegrationEventHandler(Type type) =>
        type.IsGenericType &&
        type.Name.StartsWith(_integrationEventHandlerType.Name, StringComparison.InvariantCulture);
}
