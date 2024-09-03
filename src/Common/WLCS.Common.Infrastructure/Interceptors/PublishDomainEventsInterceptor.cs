// <copyright file="PublishDomainEventsInterceptor.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Interceptors;

public sealed class PublishDomainEventsInterceptor(IServiceScopeFactory serviceScopeFactory) : SaveChangesInterceptor
{
  public override async ValueTask<int> SavedChangesAsync(
      SaveChangesCompletedEventData eventData,
      int result,
      CancellationToken cancellationToken = default)
  {
    ArgumentNullException.ThrowIfNull(eventData);

    if (eventData.Context is not null)
    {
      await PublishDomainEventsAsync(eventData.Context);
    }

    return await base.SavedChangesAsync(eventData, result, cancellationToken);
  }

  private async Task PublishDomainEventsAsync(DbContext context)
  {
    var domainEvents = context
        .ChangeTracker
        .Entries<IEntity>()
        .Select(entry => entry.Entity)
        .SelectMany(entity =>
        {
          IReadOnlyCollection<IDomainEvent> domainEvents = entity.GetDomainEvents();

          entity.ClearDomainEvents();

          return domainEvents;
        })
        .ToList();

    using IServiceScope scope = serviceScopeFactory.CreateScope();

    IPublisher publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

    foreach (IDomainEvent domainEvent in domainEvents)
    {
      await publisher.Publish(domainEvent);
    }
  }
}
