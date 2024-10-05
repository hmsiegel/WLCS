// <copyright file="UpdateCompetitionCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.UpdateCompetition;

internal sealed class UpdateCompetitionCommandHandler(
  ICompetitionRepository competitionRepository,
  IUnitOfWork unitOfWork)
  : ICommandHandler<UpdateCompetitionCommand>
{
  private readonly ICompetitionRepository _competitionRepository = competitionRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<Result> Handle(UpdateCompetitionCommand request, CancellationToken cancellationToken)
  {
    var competition = await _competitionRepository.GetAsync(request.CompetitionId, cancellationToken);

    if (competition is null)
    {
      return Result.Failure(CompetitionErrors.NotFound(request.CompetitionId));
    }

    competition.Update(
      CompetitionName.Create(request.Name).Value,
      Scope.FromName(request.Scope),
      CompetitionType.FromName(request.CompetitionType),
      AgeDivision.FromName(request.AgeDivision));

    _competitionRepository.Update(competition);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
