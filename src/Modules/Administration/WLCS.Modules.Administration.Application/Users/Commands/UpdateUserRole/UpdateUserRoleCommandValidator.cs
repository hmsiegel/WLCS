// <copyright file="UpdateUserRoleCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.UpdateUserRole;

internal sealed class UpdateUserRoleCommandValidator : AbstractValidator<UpdateUserRoleCommand>
{
  public UpdateUserRoleCommandValidator()
  {
    RuleFor(x => x.UserId)
      .NotEmpty();

    RuleFor(x => x.UserRole)
      .NotEmpty();
  }
}
