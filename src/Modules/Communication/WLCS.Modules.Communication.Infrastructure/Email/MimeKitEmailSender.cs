// <copyright file="MimeKitEmailSender.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Email;

internal sealed class MimeKitEmailSender(ILogger<MimeKitEmailSender> logger, IDateTimeProvider dateTimeProvider) : ISendEmail
{
  private readonly ILogger<MimeKitEmailSender> _logger = logger;
  private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

  public async Task SendEmailAsync(
    string to,
    string from,
    string subject,
    string body,
    string? cc = null,
    string? bcc = null,
    string? replyTo = null,
    CancellationToken cancellationToken = default)
  {
    _logger.AttemptingToSendEmailMessage(to, from, subject, _dateTimeProvider.UtcNow);

    using var client = new SmtpClient();
    await client.ConnectAsync(Constants.Localhost, 25, false, cancellationToken);
    MimeMessage message = null!;

    try
    {
      message = new MimeMessage();
      message.To.Add(new MailboxAddress(to, to));
      message.From.Add(new MailboxAddress(from, from));
      message.Cc.Add(new MailboxAddress(cc, cc));
      message.Bcc.Add(new MailboxAddress(bcc, bcc));
      message.ReplyTo.Add(new MailboxAddress(replyTo, replyTo));
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
