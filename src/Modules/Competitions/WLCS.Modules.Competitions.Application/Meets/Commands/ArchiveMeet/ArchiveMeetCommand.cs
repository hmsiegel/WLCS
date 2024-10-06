// <copyright file="ArchiveMeetCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Commands.ArchiveMeet;

public sealed record ArchiveMeetCommand(Guid MeetId) : ICommand;
