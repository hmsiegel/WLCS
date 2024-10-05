// <copyright file="CreateCompetition.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Modules.Competitions.Application.Competitions.Commands.UpdateCompetition;

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal sealed class CreateCompetition(ISender sender) : Endpoint<CompetitionRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("meets/{meetId}/competition");
    Policies(Presentation.Permissions.CreateCompetition);
    Options(opt => opt.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(CompetitionRequest req, CancellationToken ct)
  {
    var meetId = Route<Guid>("meetId");

    var command = new CreateCompetitionCommand(
      meetId,
      req.Name,
      req.Scope,
      req.CompetitionType,
      req.AgeDivision);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendAsync(result.Value, statusCode: StatusCodes.Status200OK, cancellation: ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
