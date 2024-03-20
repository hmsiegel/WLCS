namespace Modules.Users.Infrastructure.Consumers;

/// <summary>
/// Represents the consumer configuration for the users module.
/// </summary>
internal sealed class ConsumerConfiguration : IConsumerConfiguration
{
    /// <inheritdoc/>
    public void AddConsumers(IRegistrationConfigurator registrationConfigurator)
    {
        registrationConfigurator.AddConsumer<UserPermissionsRequestConsumer>();
    }
}
