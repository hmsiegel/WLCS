// <copyright file="CreateMeetCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using MediatR;

namespace WLCS.Modules.Competition.Application.Meets.Command.CreateMeet;

/// <summary>
/// Creates a new meet.
/// </summary>
/// <param name="Name">The name of the meet.</param>
/// <param name="Location">The city and state of the meet.</param>
/// <param name="Venue">The venue of the meet.</param>
/// <param name="StartDate">The local start date of the meet.</param>
/// <param name="EndDate">The local end date of the meet.</param>
public sealed record CreateMeetCommand(
  string Name,
  string Location,
  string Venue,
  DateOnly StartDate,
  DateOnly EndDate)
  : IRequest<Guid>;
