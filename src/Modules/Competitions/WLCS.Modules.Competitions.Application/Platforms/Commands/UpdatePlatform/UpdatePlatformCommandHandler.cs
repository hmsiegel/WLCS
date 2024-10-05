// <copyright file="UpdatePlatformCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Commands.UpdatePlatform;

internal sealed class UpdatePlatformCommandHandler(
  IPlatformRepository platformRepository,
  IUnitOfWork unitOfWork)
  : ICommandHandler<UpdatePlatformCommand>
{
  private readonly IPlatformRepository _platformRepository = platformRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<Result> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
  {
    var platform = await _platformRepository.GetAsync(request.PlatformId, cancellationToken);

    if (platform is null)
    {
      return Result.Failure(PlatformErrors.NotFound(request.PlatformId));
    }

    platform.Update(PlatformName.Create(request.PlatformName).Value);

    _platformRepository.Update(platform);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
