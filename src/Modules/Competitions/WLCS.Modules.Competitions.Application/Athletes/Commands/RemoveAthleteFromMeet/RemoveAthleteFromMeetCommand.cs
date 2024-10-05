// <copyright file="RemoveAthleteFromMeetCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Athletes.Commands.RemoveAthleteFromMeet;

public sealed record RemoveAthleteFromMeetCommand(Guid MeetId, Guid AthleteId) : ICommand;
