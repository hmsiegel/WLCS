// <copyright file="RegisterUserCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
  public RegisterUserCommandValidator()
  {
    RuleFor(x => x.Email)
        .NotEmpty()
        .EmailAddress();

    RuleFor(x => x.Password)
        .MinimumLength(8)
        .NotEmpty();

    RuleFor(x => x.FirstName)
        .NotEmpty();

    RuleFor(x => x.LastName)
        .NotEmpty();
  }
}
