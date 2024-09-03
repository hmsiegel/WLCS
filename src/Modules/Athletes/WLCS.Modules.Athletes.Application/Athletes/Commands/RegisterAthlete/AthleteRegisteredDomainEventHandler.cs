// <copyright file="AthleteRegisteredDomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Application.Athletes.Commands.RegisterAthlete;

internal sealed class AthleteRegisteredDomainEventHandler(
  IEventBus eventBus,
  ISender sender)
  : IDomainEventHandler<AthleteRegisteredDomainEvent>
{
  private readonly IEventBus _eventBus = eventBus;
  private readonly ISender _sender = sender;

  public async Task Handle(AthleteRegisteredDomainEvent notification, CancellationToken cancellationToken)
  {
    var query = new GetAthleteQuery(notification.AthleteId);

    var result = await _sender.Send(query, cancellationToken);

    if (result.IsFailure)
    {
      throw new WlcsException(nameof(GetAthleteQuery), result.Errors[0]);
    }

    await _eventBus.PublishAsync(
      new AthleteRegisteredIntegrationEvent(
        notification.Id,
        notification.OccurredOnUtc,
        result.Value.Id,
        result.Value.MembershipId,
        result.Value.FirstName,
        result.Value.LastName,
        result.Value.DateOfBirth,
        Gender.FromName(result.Value.Gender)),
      cancellationToken);
  }
}
