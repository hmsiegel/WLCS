// <copyright file="UpdateAthleteCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Athletes.Commands.UpdateAthlete;

internal sealed class UpdateAthleteCommandValidator : AbstractValidator<UpdateAthleteCommand>
{
  public UpdateAthleteCommandValidator()
  {
    RuleFor(x => x.AthleteId)
      .NotEmpty();

    RuleFor(x => x.FirstName)
      .NotEmpty();

    RuleFor(x => x.LastName)
      .NotEmpty();

    RuleFor(x => x.Club)
      .NotEmpty();

    RuleFor(x => x.Coach)
      .NotEmpty();
  }
}
