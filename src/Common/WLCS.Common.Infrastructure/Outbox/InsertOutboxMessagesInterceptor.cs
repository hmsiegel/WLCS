﻿// <copyright file="InsertOutboxMessagesInterceptor.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Outbox;

public sealed class InsertOutboxMessagesInterceptor : SaveChangesInterceptor
{
  public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
    DbContextEventData eventData,
    InterceptionResult<int> result,
    CancellationToken cancellationToken = default)
  {
    ArgumentNullException.ThrowIfNull(eventData);

    if (eventData.Context is not null)
    {
      InsertOutboxMessages(eventData.Context);
    }

    return await base.SavingChangesAsync(eventData, result, cancellationToken);
  }

  private static void InsertOutboxMessages(DbContext context)
  {
    var outboxMessages = context
      .ChangeTracker
      .Entries<IEntity>()
      .Select(entry => entry.Entity)
      .SelectMany(entity =>
      {
        var domainEvents = entity.GetDomainEvents();

        entity.ClearDomainEvents();

        return domainEvents;
      })
      .Select(domainEvent => new OutboxMessage
      {
        Id = domainEvent.Id,
        Type = domainEvent.GetType().Name,
        Content = JsonConvert.SerializeObject(domainEvent, SerializerSettings.Instance),
        OccurredOnUtc = domainEvent.OccurredOnUtc,
      })
      .ToList();

    context.Set<OutboxMessage>().AddRange(outboxMessages);
  }
}
