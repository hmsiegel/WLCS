// <copyright file="AthleteRegisteredDomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Application.Athletes.Commands.RegisterAthlete;

internal sealed class AthleteRegisteredDomainEventHandler(
  ICompetitionsApi competitionsApi,
  ISender sender)
  : IDomainEventHandler<AthleteRegisteredDomainEvent>
{
  private readonly ISender _sender = sender;
  private readonly ICompetitionsApi _competitionsApi = competitionsApi;

  public async Task Handle(AthleteRegisteredDomainEvent notification, CancellationToken cancellationToken)
  {
    var query = new GetAthleteQuery(notification.AthleteId);

    var result = await _sender.Send(query, cancellationToken);

    if (result.IsFailure)
    {
      throw new WlcsException(nameof(GetAthleteQuery), result.Errors[0]);
    }

    await _competitionsApi.CreateAthleteAsync(
      result.Value.Id,
      result.Value.MembershipId,
      result.Value.FirstName,
      result.Value.LastName,
      result.Value.DateOfBirth,
      result.Value.Gender,
      cancellationToken);
  }
}
