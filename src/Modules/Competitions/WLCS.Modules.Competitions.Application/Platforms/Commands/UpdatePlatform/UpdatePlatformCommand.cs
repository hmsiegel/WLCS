// <copyright file="UpdatePlatformCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Commands.UpdatePlatform;

public sealed record UpdatePlatformCommand(Guid PlatformId, string PlatformName) : ICommand;
