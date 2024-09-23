// <copyright file="CreatePlatformCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Commands.CreatePlatform;

public sealed record CreatePlatformCommand(string Name, Guid MeetId) : ICommand<Guid>;
