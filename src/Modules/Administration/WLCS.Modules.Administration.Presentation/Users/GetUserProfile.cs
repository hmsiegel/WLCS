// <copyright file="GetUserProfile.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class GetUserProfile(ISender sender) : EndpointWithoutRequest<UserResponse>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Get("users/{id}/profile");
    AllowAnonymous();
    Options(o => o.WithTags(SwaggerTags.Users));
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var id = Route<Guid>("id");

    var query = new GetUserQuery(id);

    var results = await _sender.Send(query, ct);

    if (results.IsSuccess)
    {
      await SendResultAsync(TypedResults.Ok(results.Value));
    }
    else
    {
      await SendResultAsync(TypedResults.Problem());
    }
  }
}
