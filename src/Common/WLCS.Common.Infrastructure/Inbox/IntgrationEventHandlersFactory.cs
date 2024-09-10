// <copyright file="IntgrationEventHandlersFactory.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Inbox;

public static class IntgrationEventHandlersFactory
{
  private static readonly ConcurrentDictionary<string, Type[]> _handlersDictionary = [];

  public static IEnumerable<IIntegrationEventHandler> GetHandlers(
    Type type,
    IServiceProvider serviceProvider,
    Assembly assembly)
  {
    ArgumentNullException.ThrowIfNull(type);
    ArgumentNullException.ThrowIfNull(assembly);

    Type[] integrationEventHandlerTypes = _handlersDictionary.GetOrAdd(
      $"{assembly.GetName().Name}{type.Name}",
      _ =>
      {
        Type[] integrationEventHandlerTypes = assembly.GetTypes()
          .Where(t => t.IsAssignableTo(typeof(IIntegrationEventHandler<>).MakeGenericType(type)))
          .ToArray();

        return integrationEventHandlerTypes;
      });

    List<IIntegrationEventHandler> handlers = [];

    foreach (var integrationEventHandlerType in integrationEventHandlerTypes)
    {
      object integrationEventHandler = serviceProvider.GetRequiredService(integrationEventHandlerType);

      handlers.Add((integrationEventHandler as IIntegrationEventHandler)!);
    }

    return handlers;
  }
}
