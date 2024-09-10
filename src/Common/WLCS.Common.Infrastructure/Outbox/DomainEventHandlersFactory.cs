// <copyright file="DomainEventHandlersFactory.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Outbox;

public static class DomainEventHandlersFactory
{
  private static readonly ConcurrentDictionary<string, Type[]> _handlersDictionary = [];

  public static IEnumerable<IDomainEventHandler> GetHandlers(
    Type type,
    IServiceProvider serviceProvider,
    Assembly assembly)
  {
    ArgumentNullException.ThrowIfNull(type);
    ArgumentNullException.ThrowIfNull(assembly);

    Type[] domainEventHandlerTypes = _handlersDictionary.GetOrAdd(
      $"{assembly.GetName().Name}{type.Name}",
      _ =>
      {
        Type[] domainEventHandlerTypes = assembly.GetTypes()
          .Where(t => t.IsAssignableTo(typeof(IDomainEventHandler<>).MakeGenericType(type)))
          .ToArray();

        return domainEventHandlerTypes;
      });

    List<IDomainEventHandler> handlers = [];

    foreach (var domainEventHandlerType in domainEventHandlerTypes)
    {
      object domainEventHandler = serviceProvider.GetRequiredService(domainEventHandlerType);

      handlers.Add((domainEventHandler as IDomainEventHandler)!);
    }

    return handlers;
  }
}
