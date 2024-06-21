// <copyright file="PublishDomainEventsInterceptor.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Interceptors;

/// <summary>
/// Initializes a new instance of the <see cref="PublishDomainEventsInterceptor"/> class.
/// </summary>
/// <param name="serviceScopeFactory">The service scope factory.</param>
public sealed class PublishDomainEventsInterceptor(IServiceScopeFactory serviceScopeFactory) : SaveChangesInterceptor
{
  private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

  /// <inheritdoc/>
  public override async ValueTask<int> SavedChangesAsync(
    SaveChangesCompletedEventData eventData,
    int result,
    CancellationToken cancellationToken = default)
  {
    if (eventData is null)
    {
      return await base.SavedChangesAsync(eventData!, result, cancellationToken)
        .ConfigureAwait(false);
    }

    if (eventData.Context is not null)
    {
      await PublishDomainEventsAsync(eventData.Context)
        .ConfigureAwait(false);
    }

    return await base.SavedChangesAsync(eventData, result, cancellationToken)
      .ConfigureAwait(false);
  }

  private async Task PublishDomainEventsAsync(DbContext context)
  {
    var domainEvents = context
      .ChangeTracker
      .Entries<Entity>()
      .Select(entry => entry.Entity)
      .SelectMany(entity =>
      {
        var domainEvents = entity.DomainEvents;

        entity.ClearDomainEvents();

        return domainEvents;
      })
      .ToList();

    using var scope = _serviceScopeFactory.CreateScope();

    var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

    foreach (var domainEvent in domainEvents)
    {
      await publisher.Publish(domainEvent)
        .ConfigureAwait(false);
    }
  }
}
