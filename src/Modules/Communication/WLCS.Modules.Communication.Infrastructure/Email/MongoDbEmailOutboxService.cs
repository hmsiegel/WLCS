// <copyright file="MongoDbEmailOutboxService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Email;

internal sealed class MongoDbEmailOutboxService
  : IOutboxService
{
  private readonly IMongoCollection<EmailOutboxEntity> _emailCollection;

  public MongoDbEmailOutboxService(IMongoClient mongoClient)
  {
    var mongoDatabase = mongoClient.GetDatabase(DocumentDbSettings.Database);
    _emailCollection = mongoDatabase.GetCollection<EmailOutboxEntity>(DocumentDbSettings.EmailOutboxCollection);
  }

  public async Task QueueEmailForSending(EmailOutboxEntity entity)
  {
    await _emailCollection.InsertOneAsync(entity);
  }
}
