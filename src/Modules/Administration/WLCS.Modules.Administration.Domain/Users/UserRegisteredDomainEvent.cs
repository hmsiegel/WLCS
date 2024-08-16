// <copyright file="UserRegisteredDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

public sealed class UserRegisteredDomainEvent(Guid userId) : DomainEvent
{
  public Guid UserId { get; private set; } = userId;
}
