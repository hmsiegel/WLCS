// <copyright file="UpdateUserRole.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class UpdateUserRole(ISender sender) : Endpoint<UpdateUserRoleRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Put("user/{id}/roles");
    Policies(Presentation.Permissions.ModifyUser);
    Options(opt => opt.WithTags(Presentation.Tags.Users));
  }

  public override async Task HandleAsync(UpdateUserRoleRequest req, CancellationToken ct)
  {
    var userId = Route<Guid>("id");

    var command = new UpdateUserRoleCommand(
      userId,
      req.RoleName);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendAsync(result, StatusCodes.Status200OK, ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
