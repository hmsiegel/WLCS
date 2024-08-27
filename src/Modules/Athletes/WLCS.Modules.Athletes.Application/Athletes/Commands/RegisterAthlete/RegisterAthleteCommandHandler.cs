// <copyright file="RegisterAthleteCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Application.Athletes.Commands.RegisterAthlete;

internal sealed class RegisterAthleteCommandHandler(
  IUnitOfWork unitOfWork,
  IAthleteRepository athleteRepository)
  : ICommandHandler<RegisterAthleteCommand, Guid>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IAthleteRepository _athleteRepository = athleteRepository;

  public async Task<Result<Guid>> Handle(RegisterAthleteCommand request, CancellationToken cancellationToken)
  {
    if (!await _athleteRepository.AthleteExistsAsync(request.MembershipId, cancellationToken))
    {
      return Result.Failure<Guid>(AthleteErrors.AthleteAlreadExists(request.MembershipId));
    }

    var membershipIdResult = Membership.Create(request.MembershipId);
    var firstNameResult = FirstName.Create(request.FirstName);
    var lastNameResult = LastName.Create(request.LastName);

    var emailResult = Email.Create(request.Email);

    if (emailResult.IsFailure)
    {
      return Result.Failure<Guid>(emailResult.Errors);
    }

    if (!await _athleteRepository.IsEmailUniqueAsync(emailResult.Value, cancellationToken))
    {
      return Result.Failure<Guid>(AthleteErrors.EmailAlreadyInUse);
    }

    var athlete = Athlete.Create(
      membershipIdResult.Value,
      firstNameResult.Value,
      lastNameResult.Value,
      request.DateOfBirth,
      emailResult.Value,
      Gender.FromName(request.Gender));

    _athleteRepository.Add(athlete);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return athlete.Id.Value;
  }
}
