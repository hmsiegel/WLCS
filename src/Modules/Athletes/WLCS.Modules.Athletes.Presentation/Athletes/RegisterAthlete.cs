// <copyright file="RegisterAthlete.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Presentation.Athletes;

internal sealed partial class RegisterAthlete(ISender sender) : Endpoint<RegisterAthleteRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("athletes");
    AllowAnonymous();
    Options(x => x.WithTags(SwaggerTags.Athletes));
  }

  public override async Task HandleAsync(RegisterAthleteRequest req, CancellationToken ct)
  {
    var command = new RegisterAthleteCommand(
      req.MembershipId,
      req.FirstName,
      req.LastName,
      req.DateOfBirth,
      req.Email,
      req.Gender);

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
