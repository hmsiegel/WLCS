namespace Modules.Users.Infrastructure.ServiceInstallers;

/// <summary>
/// Represents the users module application service installer.
/// </summary>
internal sealed class ApplicationServiceInstaller : IServiceInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration) =>
        services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
            })
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            .AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true)
            .Tap(DecorateDomainEventHandlersWithIdempotency)
            .Tap(AddAndDecorateIntegrationEventHandlersWithIdempotency);

    private static void DecorateDomainEventHandlersWithIdempotency(IServiceCollection services) =>
        Application.AssemblyReference.Assembly
            .GetTypes()
            .Where(EventHandlersUtility.ImplementsDomainEventHandler)
            .ForEach(type =>
            {
                Type closedNotificationHandler = type.GetInterfaces().First(EventHandlersUtility.IsNotificationHandler);

                Type[] arguments = closedNotificationHandler.GetGenericArguments();

                Type closedIdempotentHandler = typeof(IdempotentDomainEventHandler<>).MakeGenericType(arguments);

                services.Decorate(closedNotificationHandler, closedIdempotentHandler);
            });

    private static void AddAndDecorateIntegrationEventHandlersWithIdempotency(IServiceCollection services) =>
        Application.AssemblyReference.Assembly
            .GetTypes()
            .Where(EventHandlersUtility.ImplementsIntegrationEventHandler)
            .ForEach(integrationEventHandlerType =>
            {
                Type closedIntegrationEventHandler = integrationEventHandlerType
                    .GetInterfaces()
                    .First(EventHandlersUtility.IsIntegrationEventHandler);

                Type[] arguments = closedIntegrationEventHandler.GetGenericArguments();

                Type closedIdempotentHandler = typeof(IdempotentIntegrationEventHandler<>).MakeGenericType(arguments);

                services.AddScoped(integrationEventHandlerType);

                services.Decorate(integrationEventHandlerType, closedIdempotentHandler);
            });
}
