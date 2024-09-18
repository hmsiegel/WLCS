// <copyright file="SendEmailCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Application.Commands.SendEmail;

internal sealed class SendEmailCommandHandler(ISendEmail emailSender) : ICommandHandler<SendEmailCommand, Guid>
{
  private readonly ISendEmail _emailSender = emailSender;

  public async Task<Result<Guid>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
  {
    await _emailSender.SendEmailAsync(
      request.To,
      request.From,
      request.Subject,
      request.Body,
      request.Cc,
      request.Bcc,
      request.ReplyTo,
      cancellationToken);

    return Guid.Empty;
  }
}
