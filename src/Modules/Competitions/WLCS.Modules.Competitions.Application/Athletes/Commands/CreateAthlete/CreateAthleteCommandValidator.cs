// <copyright file="CreateAthleteCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Athletes.Commands.CreateAthlete;

internal sealed class CreateAthleteCommandValidator : CustomValidator<CreateAthleteCommand>
{
  public CreateAthleteCommandValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.Membership).NotEmpty();
    RuleFor(x => x.FirstName).NotEmpty();
    RuleFor(x => x.LastName).NotEmpty();
    RuleFor(x => x.DateOfBirth).NotEmpty();
    RuleFor(x => x.Gender).NotEmpty();
  }
}
