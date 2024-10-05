// <copyright file="RemoveCompetitionFromMeetCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.RemoveCompetitionFromMeet;

public sealed record RemoveCompetitionFromMeetCommand(Guid MeetId, Guid CompetitionId) : ICommand;
