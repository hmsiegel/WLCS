// <copyright file="AthleteRegisteredIntegrationEventConsumer.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Athletes;

public sealed class AthleteRegisteredIntegrationEventConsumer(ISender sender)
  : IConsumer<AthleteRegisteredIntegrationEvent>
{
  private readonly ISender _sender = sender;

  public async Task Consume(ConsumeContext<AthleteRegisteredIntegrationEvent> context)
  {
    ArgumentNullException.ThrowIfNull(context);

    var command = new CreateAthleteCommand(
      context.Message.AthleteId,
      context.Message.MembershipId,
      context.Message.FirstName,
      context.Message.LastName,
      context.Message.DateOfBirth,
      context.Message.Gender.Name);

    var result = await _sender.Send(command, context.CancellationToken);

    if (result.IsFailure)
    {
      throw new WlcsException(nameof(CreateAthleteCommand), result.Errors[0]);
    }
  }
}
