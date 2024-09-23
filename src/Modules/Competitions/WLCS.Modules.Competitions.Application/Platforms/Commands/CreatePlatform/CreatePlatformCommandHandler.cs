// <copyright file="CreatePlatformCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Commands.CreatePlatform;

internal sealed class CreatePlatformCommandHandler(
  IMeetRepository meetRepository,
  IPlatformRepository platformRepository,
  IUnitOfWork unitOfWork)
  : ICommandHandler<CreatePlatformCommand, Guid>
{
  private readonly IMeetRepository _meetRepository = meetRepository;
  private readonly IPlatformRepository _platformRepository = platformRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<Result<Guid>> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
  {
    var meet = await _meetRepository.GetAsync(request.MeetId, cancellationToken);

    if (meet is null)
    {
      return Result.Failure<Guid>(MeetErrors.NotFound(request.MeetId));
    }

    var platform = Platform.Create(meet.Id, PlatformName.Create(request.Name).Value);

    _platformRepository.Add(platform);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return platform.Id.Value;
  }
}
