// <copyright file="AddAthleteToCompetitionCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.AddAthleteToCompetition;

internal sealed class AddAthleteToCompetitionCommandValidator : AbstractValidator<AddAthleteToCompetitionCommand>
{
  public AddAthleteToCompetitionCommandValidator()
  {
    RuleFor(x => x.AthleteId)
      .NotEmpty()
      .WithMessage("AthleteId is required");

    RuleFor(x => x.CompetitionId)
      .NotEmpty()
      .WithMessage("CompetitionId is required");
  }
}
