// <copyright file="SendEmailCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Application.Commands.SendEmail;

public sealed record SendEmailCommand(
    string To,
    string Subject,
    string Body,
    string? Cc = null,
    string? Bcc = null) : ICommand<Guid>;
