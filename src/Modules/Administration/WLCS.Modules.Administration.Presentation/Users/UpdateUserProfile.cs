// <copyright file="UpdateUserProfile.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class UpdateUserProfile(ISender sender) : Endpoint<UpdateUserRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Put("users/update");
    Policies(Presentation.Permissions.ModifyUser);
    Options(opt => opt.WithTags(Presentation.Tags.Users));
  }

  public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
  {
    var command = new UpdateUserCommand(
     User.GetUserId(),
     req.FirstName,
     req.LastName);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendOkAsync(ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
