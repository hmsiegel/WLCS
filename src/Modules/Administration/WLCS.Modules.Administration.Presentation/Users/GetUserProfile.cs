// <copyright file="GetUserProfile.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using IMapper = MapsterMapper.IMapper;

namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class GetUserProfile(ISender sender, IMapper mapper) : EndpointWithoutRequest<UserResponse>
{
  private readonly ISender _sender = sender;
  private readonly IMapper _mapper = mapper;

  public override void Configure()
  {
    Get("users/profile");
    Permissions(Presentation.Permissions.GetUser);
    Options(opt => opt.WithTags(Presentation.Tags.Users));
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var query = new GetUserQuery(User.GetUserId());

    var result = await _sender.Send(query, ct);

    if (result.IsSuccess)
    {
      var response = _mapper.Map<UserResponse>(result.Value);

      await SendAsync(response, StatusCodes.Status200OK, ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
