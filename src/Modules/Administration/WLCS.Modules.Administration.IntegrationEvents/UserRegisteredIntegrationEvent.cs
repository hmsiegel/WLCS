// <copyright file="UserRegisteredIntegrationEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Common.Application.EventBus;

namespace WLCS.Modules.Administration.IntegrationEvents;

public sealed class UserRegisteredIntegrationEvent(
  Guid id,
  DateTime occurredOnUtc,
  Guid userId,
  string email,
  string firstName,
  string lastName)
  : IntegrationEvent(id, occurredOnUtc)
{
  public Guid UserId { get; init; } = userId;

  public string Email { get; init; } = email;

  public string FirstName { get; init; } = firstName;

  public string LastName { get; init; } = lastName;
}
