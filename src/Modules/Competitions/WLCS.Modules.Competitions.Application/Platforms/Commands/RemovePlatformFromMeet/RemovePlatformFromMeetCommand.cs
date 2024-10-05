// <copyright file="RemovePlatformFromMeetCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Commands.RemovePlatformFromMeet;

public sealed record RemovePlatformFromMeetCommand(Guid MeetId, Guid PlatformId) : ICommand;
