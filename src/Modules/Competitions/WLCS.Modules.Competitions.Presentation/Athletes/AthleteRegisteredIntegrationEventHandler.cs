// <copyright file="AthleteRegisteredIntegrationEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Athletes;

internal sealed class AthleteRegisteredIntegrationEventHandler(ISender sender)
  : IntegrationEventHandler<AthleteRegisteredIntegrationEvent>
{
  private readonly ISender _sender = sender;

  public override async Task Handle(AthleteRegisteredIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
  {
    ArgumentNullException.ThrowIfNull(integrationEvent);

    var command = new CreateAthleteCommand(
      integrationEvent.AthleteId,
      integrationEvent.MembershipId,
      integrationEvent.FirstName,
      integrationEvent.LastName,
      integrationEvent.DateOfBirth,
      integrationEvent.Gender.Name);

    var result = await _sender.Send(command, cancellationToken);

    if (result.IsFailure)
    {
      throw new WlcsException(nameof(CreateAthleteCommand), result.Errors[0]);
    }
  }
}
