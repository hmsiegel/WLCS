// <copyright file="SendEmailService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Application.Commands.SendEmail;

public sealed record SendEmailService(
    string To,
    string Subject,
    string Body,
    string? Cc = null,
    string? Bcc = null) : IRequest<Result<Guid>>;
