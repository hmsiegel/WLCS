// <copyright file="CreateCompetition.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal sealed partial class CreateCompetition(ISender sender) : Endpoint<CreateCompetitionRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("meets/{meetId}/competition");
    AllowAnonymous();
    Options(x => x.WithTags(SwaggerTags.Competitions));
  }

  public override async Task HandleAsync(CreateCompetitionRequest req, CancellationToken ct)
  {
    var command = new CreateCompetitionCommand(
      req.MeetId,
      req.Name,
      req.Scope,
      req.CompetitionType,
      req.AgeDivision);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendResultAsync(TypedResults.Ok(result.Value));
    }
    else
    {
      await SendResultAsync(TypedResults.Problem());
    }
  }
}
