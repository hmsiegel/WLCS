// <copyright file="CreateAthleteCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Athletes.Commands.CreateAthlete;

internal sealed class CreateAthleteCommandHandler(IAthleteRepository athleteRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateAthleteCommand>
{
  private readonly IAthleteRepository _athleteRepository = athleteRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<Result> Handle(CreateAthleteCommand request, CancellationToken cancellationToken)
  {
    var athlete = Athlete.Create(
      request.Id,
      request.Membership,
      request.FirstName,
      request.LastName,
      request.DateOfBirth,
      Gender.FromName(request.Gender));

    _athleteRepository.Add(athlete);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
