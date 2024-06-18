// <copyright file="MeetCreatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Domain.Meets.DomainEvents;

/// <summary>
/// The domain event that is raised when a meet is created.
/// </summary>
/// <param name="meetId">The unique identifier of the meet.</param>
public sealed class MeetCreatedDomainEvent(Guid meetId) : DomainEvent
{
  /// <summary>
  /// Gets the unique identifier of the meet.
  /// </summary>
  public Guid MeetId { get; } = meetId;
}
