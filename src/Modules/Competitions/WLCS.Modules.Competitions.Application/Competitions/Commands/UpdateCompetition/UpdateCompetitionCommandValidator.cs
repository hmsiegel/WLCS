// <copyright file="UpdateCompetitionCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.UpdateCompetition;

internal sealed class UpdateCompetitionCommandValidator : AbstractValidator<UpdateCompetitionCommand>
{
  public UpdateCompetitionCommandValidator()
  {
    RuleFor(x => x.CompetitionId)
      .NotEmpty();

    RuleFor(x => x.Name)
      .NotEmpty()
      .MaximumLength(100);

    RuleFor(x => x.Scope)
      .NotEmpty()
      .MaximumLength(100);

    RuleFor(x => x.CompetitionType)
      .NotEmpty()
      .MaximumLength(100);

    RuleFor(x => x.AgeDivision)
      .NotEmpty()
      .MaximumLength(100);
  }
}
