// <copyright file="UpdateUserCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.UpdateUser;

/// <summary>
/// The validator for the <see cref="UpdateUserCommand"/>.
/// </summary>
internal sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
  /// <summary>
  /// Initializes a new instance of the <see cref="UpdateUserCommandValidator"/> class.
  /// </summary>
  public UpdateUserCommandValidator()
  {
    RuleFor(x => x.UserId)
      .NotEmpty();

    RuleFor(x => x.FirstName)
      .NotEmpty()
      .MaximumLength(50);

    RuleFor(x => x.LastName)
      .NotEmpty()
      .MaximumLength(50);
  }
}
