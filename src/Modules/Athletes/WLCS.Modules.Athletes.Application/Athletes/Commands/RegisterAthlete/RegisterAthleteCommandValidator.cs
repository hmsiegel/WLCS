// <copyright file="RegisterAthleteCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Application.Athletes.Commands.RegisterAthlete;

internal sealed class RegisterAthleteCommandValidator : AbstractValidator<RegisterAthleteCommand>
{
  public RegisterAthleteCommandValidator()
  {
    RuleFor(x => x.MembershipId).NotNull();
    RuleFor(x => x.FirstName).NotNull();
    RuleFor(x => x.LastName).NotNull();
    RuleFor(x => x.DateOfBirth).NotNull();
    RuleFor(x => x.Gender).NotNull();
  }
}
