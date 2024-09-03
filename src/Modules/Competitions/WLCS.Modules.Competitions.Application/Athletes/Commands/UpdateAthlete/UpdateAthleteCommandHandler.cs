// <copyright file="UpdateAthleteCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Athletes.Commands.UpdateAthlete;

internal sealed class UpdateAthleteCommandHandler(
  IAthleteRepository athleteRepository,
  IUnitOfWork unitOfWork)
  : ICommandHandler<UpdateAthleteCommand>
{
  private readonly IAthleteRepository _athleteRepository = athleteRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<Result> Handle(UpdateAthleteCommand request, CancellationToken cancellationToken)
  {
    var athlete = await _athleteRepository.GetAsync(request.AthleteId, cancellationToken);

    if (athlete is null)
    {
      return Result.Failure(AthleteErrors.NotFound(request.AthleteId));
    }

    athlete.Update(request.FirstName, request.LastName, request.Club, request.Coach);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
