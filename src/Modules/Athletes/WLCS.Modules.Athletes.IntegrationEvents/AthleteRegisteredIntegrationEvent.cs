// <copyright file="AthleteRegisteredIntegrationEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.IntegrationEvents;

public sealed class AthleteRegisteredIntegrationEvent(
  Guid id,
  DateTime occurredOnUtc,
  Guid athleteId,
  string membershipId,
  string firstName,
  string lastName,
  DateOnly dateOfBirth,
  Gender gender) : IntegrationEvent(id, occurredOnUtc)
{
  public Guid AthleteId { get; init; } = athleteId;

  public string MembershipId { get; init; } = membershipId;

  public string FirstName { get; init; } = firstName;

  public string LastName { get; init; } = lastName;

  public DateOnly DateOfBirth { get; init; } = dateOfBirth;

  public Gender Gender { get; init; } = gender;
}
