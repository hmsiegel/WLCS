// <copyright file="AddAthleteToMeetCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Commands.AddAthleteToMeet;

public sealed record AddAthleteToMeetCommand(Guid MeetId, Guid AthleteId) : ICommand;
