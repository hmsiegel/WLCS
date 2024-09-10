// <copyright file="InboxMessageConsumer.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Inbox;

public sealed class InboxMessageConsumer(Guid inboxMessageId, string name)
{
  public Guid InboxMessageId { get; init; } = inboxMessageId;

  public string Name { get; init; } = name;
}
