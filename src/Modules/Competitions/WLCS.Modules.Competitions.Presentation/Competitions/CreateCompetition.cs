// <copyright file="CreateCompetition.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal sealed class CreateCompetition(ISender sender) : Endpoint<CreateCompetitionRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("meets/{meetId}/competition");
    Policies(Presentation.Permissions.CreateCompetition);
    Options(opt => opt.WithTags(Presentation.Tags.Competitions));
  }

  public override async Task HandleAsync(CreateCompetitionRequest req, CancellationToken ct)
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
