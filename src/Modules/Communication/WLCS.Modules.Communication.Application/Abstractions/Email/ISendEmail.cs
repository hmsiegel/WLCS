﻿// <copyright file="ISendEmail.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Application.Abstractions.Email;

public interface ISendEmail
{
  Task SendEmailAsync(
    string to,
    string from,
    string subject,
    string body,
    string? cc = null,
    string? bcc = null,
    string? replyTo = null,
    CancellationToken cancellationToken = default);
}
