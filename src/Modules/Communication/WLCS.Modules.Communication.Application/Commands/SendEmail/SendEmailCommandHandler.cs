// <copyright file="SendEmailCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Application.Commands.SendEmail;

internal sealed class SendEmailCommandHandler(ISendEmail emailSender) // : ICommandHandler<SendEmailCommand, Guid>
{
  private readonly ISendEmail _emailSender = emailSender;

  public async Task<Result<Guid>> HandleAsync(SendEmailCommand request, CancellationToken cancellationToken)
  {
    await _emailSender.SendEmailAsync(
      request.To,
      request.Subject,
      request.Body,
      request.Cc,
      request.Bcc,
      cancellationToken);

    return Guid.Empty;
  }
}
