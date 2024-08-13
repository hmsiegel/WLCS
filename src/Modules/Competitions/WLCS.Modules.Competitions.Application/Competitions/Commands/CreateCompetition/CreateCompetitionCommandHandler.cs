// <copyright file="CreateCompetitionCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.CreateCompetition;

internal sealed class CreateCompetitionCommandHandler(
  ICompetitionRespository competitionRepository,
  IMeetRepository meetRepository,
  IUnitOfWork unitOfWork)
  : ICommandHandler<CreateCompetitionCommand, Guid>
{
  private readonly ICompetitionRespository _competitionRepository = competitionRepository;
  private readonly IMeetRepository _meetRepository = meetRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<Result<Guid>> Handle(CreateCompetitionCommand request, CancellationToken cancellationToken)
  {
    var meet = await _meetRepository.GetAsync(request.MeetId, cancellationToken);

    if (meet is null)
    {
      return Result.Failure<Guid>(MeetErrors.NotFound(request.MeetId));
    }

    if (!meet.IsActive)
    {
      return Result.Failure<Guid>(MeetErrors.AlreadyArchived);
    }

    var competition = Competition.Create(
      meet.Id,
      request.Name,
      request.Scope,
      request.CompetitionType,
      request.AgeDivision);

    _competitionRepository.Add(competition);

    meet.AddCompetition(competition);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success(competition.Id);
  }
}
