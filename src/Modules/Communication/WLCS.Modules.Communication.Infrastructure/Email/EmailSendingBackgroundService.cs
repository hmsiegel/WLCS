// <copyright file="EmailSendingBackgroundService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Email;

internal sealed class EmailSendingBackgroundService(
  ILogger<EmailSendingBackgroundService> logger,
  ISendEmailsFromOutboxService sendEmailsFromOutboxService)
  : BackgroundService
{
  private readonly ILogger<EmailSendingBackgroundService> _logger = logger;
  private readonly ISendEmailsFromOutboxService _sendEmailsFromOutboxService = sendEmailsFromOutboxService;

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    var delay = 5000;
    _logger.BackgroundServiceStarting(nameof(EmailSendingBackgroundService));

    while (!stoppingToken.IsCancellationRequested)
    {
      try
      {
        await _sendEmailsFromOutboxService.CheckForAndSendEmails();
      }
      catch (Exception ex)
      {
        _logger.BackgroundServiceException(ex.Message, ex);
      }
      finally
      {
        await Task.Delay(delay, stoppingToken);
      }
    }
  }
}
