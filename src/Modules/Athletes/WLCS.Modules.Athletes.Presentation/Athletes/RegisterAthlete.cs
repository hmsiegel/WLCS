// <copyright file="RegisterAthlete.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Presentation.Athletes;

internal sealed class RegisterAthlete(ISender sender) : Endpoint<CreateAthleteRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("athletes");
    Permissions(Presentation.Permissions.CreateAthlete);
    Options(opt => opt.WithTags(Presentation.Tags.Athletes));
  }

  public override async Task HandleAsync(CreateAthleteRequest req, CancellationToken ct)
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
      await SendAsync(result.Value, StatusCodes.Status200OK, ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
