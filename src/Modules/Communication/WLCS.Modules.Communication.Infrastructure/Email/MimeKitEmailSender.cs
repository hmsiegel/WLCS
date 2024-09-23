// <copyright file="MimeKitEmailSender.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using FluentEmail.Core;

namespace WLCS.Modules.Communication.Infrastructure.Email;

internal sealed class MimeKitEmailSender(
  ILogger<MimeKitEmailSender> logger,
  IDateTimeProvider dateTimeProvider,
  IOptions<EmailOptions> emailOptions,
  IFluentEmail fluentEmail)
  : ISendEmail
{
  private readonly ILogger<MimeKitEmailSender> _logger = logger;
  private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
  private readonly EmailOptions _emailOptions = emailOptions.Value;
  private readonly IFluentEmail _fluentEmail = fluentEmail;

  public async Task SendEmailAsync(
    string to,
    string subject,
    string body,
    CancellationToken cancellationToken = default)
  {
    _logger.AttemptingToSendEmailMessage(to, _emailOptions.From, subject, _dateTimeProvider.UtcNow);

    try
    {
      await _fluentEmail
        .To(to)
        .Subject(subject)
        .Body(body)
        .SendAsync(cancellationToken);

      _logger.EmailSent(_dateTimeProvider.UtcNow);
    }
    catch (Exception ex)
    {
      _logger.ErrorSendingEmail(ex.Message, ex);
      throw;
    }
  }
}
