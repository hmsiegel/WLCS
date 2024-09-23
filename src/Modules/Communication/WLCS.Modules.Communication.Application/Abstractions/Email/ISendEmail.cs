// <copyright file="ISendEmail.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Application.Abstractions.Email;

public interface ISendEmail
{
  Task SendEmailAsync(
    string to,
    string subject,
    string body,
    CancellationToken cancellationToken = default);
}
