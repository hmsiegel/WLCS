﻿// <copyright file="CreateMeetCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Competitions.Application.Meets.Commands.CreateMeet;

public sealed record CreateMeetCommand(
  string Name,
  string City,
  string State,
  string Venue,
  DateOnly StartDate,
  DateOnly EndDate) : ICommand<Guid>;
