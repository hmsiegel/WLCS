// <copyright file="CreateCompetitionCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.CreateCompetition;

internal sealed class CreateCompetitionCommandValidator : AbstractValidator<CreateCompetitionCommand>
{
  public CreateCompetitionCommandValidator()
  {
    RuleFor(x => x.MeetId).NotEmpty();
    RuleFor(x => x.Name).NotEmpty();
    RuleFor(x => x.Scope).NotEmpty();
    RuleFor(x => x.CompetitionType).NotEmpty();
    RuleFor(x => x.AgeDivision).NotEmpty();
  }
}
