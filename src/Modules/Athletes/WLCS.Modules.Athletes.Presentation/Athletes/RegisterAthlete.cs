// <copyright file="RegisterAthlete.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Presentation.Athletes;

internal sealed partial class RegisterAthlete : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("athletes", async (
      Request request,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var command = new RegisterAthleteCommand(
        request.MembershipId,
        request.FirstName,
        request.LastName,
        request.DateOfBirth,
        request.Email,
        request.Gender);

      var result = await sender.Send(command, cancellationToken);

      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization(Permissions.CreateAthlete)
    .WithTags(Tags.Athletes);
  }

  internal sealed record Request(
    string MembershipId,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Email,
    string Gender);
}
