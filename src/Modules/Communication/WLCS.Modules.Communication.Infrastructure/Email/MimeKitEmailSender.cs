// <copyright file="MimeKitEmailSender.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Email;

internal sealed class MimeKitEmailSender(
  ILogger<MimeKitEmailSender> logger,
  IDateTimeProvider dateTimeProvider,
  IOptions<EmailOptions> emailOptions)
  : ISendEmail
{
  private readonly ILogger<MimeKitEmailSender> _logger = logger;
  private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
  private readonly EmailOptions _emailOptions = emailOptions.Value;

  public async Task SendEmailAsync(
    string to,
    string subject,
    string body,
    string? cc = null,
    string? bcc = null,
    CancellationToken cancellationToken = default)
  {
    _logger.AttemptingToSendEmailMessage(to, _emailOptions.From, subject, _dateTimeProvider.UtcNow);

    using var client = new SmtpClient();
    await client.ConnectAsync(
      _emailOptions.Host,
      _emailOptions.Port,
      _emailOptions.UseSsl,
      cancellationToken);
    MimeMessage message = null!;

    try
    {
      message = new MimeMessage();
      message.To.Add(new MailboxAddress(to, to));
      message.From.Add(new MailboxAddress(_emailOptions.From, _emailOptions.From));

      if (cc is not null)
      {
        message.Cc.Add(new MailboxAddress(cc, cc));
      }

      if (bcc is not null)
      {
        message.Bcc.Add(new MailboxAddress(bcc, bcc));
      }

      message.ReplyTo.Add(new MailboxAddress(_emailOptions.From, _emailOptions.From));
      message.Subject = subject;
      message.Body = new TextPart("plain")
      {
        Text = body,
      };

      await client.SendAsync(message, cancellationToken);

      _logger.EmailSent(_dateTimeProvider.UtcNow);

      await client.DisconnectAsync(true, cancellationToken);
    }
    finally
    {
      if (message != null)
      {
        ((IDisposable)message).Dispose();
      }
    }
  }
}
