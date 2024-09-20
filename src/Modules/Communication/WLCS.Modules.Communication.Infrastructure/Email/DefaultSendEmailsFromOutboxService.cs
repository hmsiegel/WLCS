// <copyright file="DefaultSendEmailsFromOutboxService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Email;

internal sealed class DefaultSendEmailsFromOutboxService : ISendEmailsFromOutboxService
{
  private readonly ILogger<DefaultSendEmailsFromOutboxService> _logger;
  private readonly ISendEmail _emailSender;
  private readonly IOutboxService _outboxService;
  private readonly IMongoCollection<EmailOutboxEntity> _outboxCollection;

  public DefaultSendEmailsFromOutboxService(
      ILogger<DefaultSendEmailsFromOutboxService> logger,
      ISendEmail emailSender,
      IOutboxService outboxService,
      IMongoClient mongoClient)
  {
    _logger = logger;
    _emailSender = emailSender;
    _outboxService = outboxService;

    var mongoDatabase = mongoClient.GetDatabase(DocumentDbSettings.Database);
    _outboxCollection = mongoDatabase.GetCollection<EmailOutboxEntity>(
      DocumentDbSettings.EmailOutboxCollection);
  }

  public async Task CheckForAndSendEmails()
  {
    try
    {
      var result = await _outboxService.GetUnprocessedEmailEntity();

      if (result.IsFailure)
      {
        return;
      }

      var emailEntity = result.Value;

      await _emailSender.SendEmailAsync(
        emailEntity.To,
        emailEntity.Subject,
        emailEntity.Body);

      var updateFilter = Builders<EmailOutboxEntity>
        .Filter.Eq(x => x.Id, emailEntity.Id);
      var update = Builders<EmailOutboxEntity>
        .Update.Set("DateTimeUtcProcessed", DateTime.UtcNow);
      var updateResult = await _outboxCollection.UpdateOneAsync(
        updateFilter,
        update);

      _logger.EmailOutboxProcessed(updateResult.ModifiedCount);
    }
    finally
    {
      _logger.Sleeping();
    }
  }
}
