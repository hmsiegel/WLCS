// <copyright file="ProcessEmailOutboxJob.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Email;

[DisallowConcurrentExecution]
internal sealed class ProcessEmailOutboxJob : IJob
{
  private readonly ILogger<ProcessEmailOutboxJob> _logger;
  private readonly IDateTimeProvider _dateTimeProvider;
  private readonly IMongoCollection<EmailOutboxEntity> _collection;
  private readonly ISendEmail _sender;

  public ProcessEmailOutboxJob(
      ILogger<ProcessEmailOutboxJob> logger,
      IDateTimeProvider dateTimeProvider,
      IMongoClient mongoClient,
      ISendEmail sender)
  {
    _logger = logger;
    _dateTimeProvider = dateTimeProvider;
    _sender = sender;

    var database = mongoClient.GetDatabase(DocumentDbSettings.Database);
    _collection = database.GetCollection<EmailOutboxEntity>(DocumentDbSettings.EmailOutboxCollection);
  }

  public async Task Execute(IJobExecutionContext context)
  {
    _logger.GettingUnprocessedEmails();

    var result = await GetUnprocessedEmailEntityAsync();

    if (result.IsFailure)
    {
      return;
    }

    var email = result.Value;

    await _sender.SendEmailAsync(
      email.To,
      email.Subject,
      email.Body);

    var updateFilter = Builders<EmailOutboxEntity>
      .Filter.Eq(x => x.Id, email.Id);
    var update = Builders<EmailOutboxEntity>
      .Update.Set("DateTimeUtcProcessed", _dateTimeProvider.UtcNow);
    var updateResult = await _collection.UpdateOneAsync(
      updateFilter,
      update);

    _logger.EmailOutboxProcessed(updateResult.ModifiedCount);
  }

  private async Task<Result<EmailOutboxEntity>> GetUnprocessedEmailEntityAsync()
  {
    var filter = Builders<EmailOutboxEntity>
      .Filter
      .Eq(entity => entity.DateTimeUtcProcessed, null);

    var unsentEmailEntity = await _collection
      .Find(filter)
      .FirstOrDefaultAsync();

    if (unsentEmailEntity is null)
    {
      return Result.Failure<EmailOutboxEntity>(EmailErrors.NotFound);
    }

    return unsentEmailEntity;
  }
}
