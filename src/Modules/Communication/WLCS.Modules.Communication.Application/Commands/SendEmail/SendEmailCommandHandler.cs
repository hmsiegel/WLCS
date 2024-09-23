// <copyright file="SendEmailCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Application.Commands.SendEmail;

internal sealed class SendEmailCommandHandler(IOutboxService outboxService)
    : ICommandHandler<SendEmailCommand, Guid>
{
  private readonly IOutboxService _outboxService = outboxService;

  public async Task<Result<Guid>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
  {
    var newEntity = new EmailOutboxEntity
    {
      Body = request.Body,
      Subject = request.Subject,
      To = request.To,
    };

    await _outboxService.QueueEmailForSending(newEntity);

    return newEntity.Id;
  }
}
