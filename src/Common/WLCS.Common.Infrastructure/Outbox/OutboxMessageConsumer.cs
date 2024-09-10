// <copyright file="OutboxMessageConsumer.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Outbox;

public sealed class OutboxMessageConsumer(Guid outboxMessageId, string name)
{
  public Guid OutboxMessageId { get; init; } = outboxMessageId;

  public string Name { get; init; } = name;
}
