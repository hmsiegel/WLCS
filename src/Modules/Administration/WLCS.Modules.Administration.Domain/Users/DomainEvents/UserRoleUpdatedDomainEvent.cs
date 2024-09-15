// <copyright file="UserRoleUpdatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users.DomainEvents;

public sealed class UserRoleUpdatedDomainEvent(Guid userId, Role userRole) : DomainEvent
{
  public Guid UserId { get; private set; } = userId;

  public Role UserRole { get; private set; } = userRole;
}
