// <copyright file="GetPlatformQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Queries.GetPlatform;

internal sealed class GetPlatformQueryHandler(IPlatformRepository platformRepository) : IQueryHandler<GetPlatformQuery, GetPlatformResponse>
{
  private readonly IPlatformRepository _platformRepository = platformRepository;

  public async Task<Result<GetPlatformResponse>> Handle(GetPlatformQuery query, CancellationToken cancellationToken)
  {
    ArgumentNullException.ThrowIfNull(query);

    var platform = await _platformRepository.GetAsync(query.PlatformId, cancellationToken);

    if (platform is null)
    {
      return Result.Failure<GetPlatformResponse>(PlatformErrors.NotFound(query.PlatformId));
    }

    return new GetPlatformResponse(platform.PlatformName.Value);
  }
}
