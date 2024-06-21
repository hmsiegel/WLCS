// <copyright file="RegisterUserCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;

/// <summary>
/// Validator for the <see cref="RegisterUserCommand"/>.
/// </summary>
internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
  /// <summary>
  /// Initializes a new instance of the <see cref="RegisterUserCommandValidator"/> class.
  /// </summary>
  public RegisterUserCommandValidator()
  {
    RuleFor(x => x.Email)
      .NotEmpty()
      .EmailAddress();

    RuleFor(x => x.Password)
      .NotEmpty()
      .MinimumLength(8);

    RuleFor(x => x.FirstName)
      .NotEmpty();

    RuleFor(x => x.LastName)
      .NotEmpty();
  }
}
