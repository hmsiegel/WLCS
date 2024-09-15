// <copyright file="UpdateUserRoleCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.UpdateUserRole;

internal sealed class UpdateUserRoleCommandHandler(
  IUserRepository userRepository,
  IRolesService rolesService)
  : ICommandHandler<UpdateUserRoleCommand>
{
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IRolesService _rolesService = rolesService;

  public async Task<Result> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetAsync(request.UserId, cancellationToken);

    if (user is null)
    {
      return Result.Failure(UserErrors.NotFound(request.UserId));
    }

    var result = await _rolesService.UpdateRole(user.Id.Value, request.UserRole, cancellationToken);

    return result;
  }
}
