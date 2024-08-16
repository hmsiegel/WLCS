// <copyright file="UpdateUserCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.UpdateUser;

internal sealed class UpdateUserCommandHandler(
  IUnitOfWork unitOfWork,
  IUserRepository userRepository)
  : ICommandHandler<UpdateUserCommand>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IUserRepository _userRepository = userRepository;

  public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetAsync(request.UserId, cancellationToken);

    if (user is null)
    {
      return Result.Failure(UserErrors.NotFoud(request.UserId));
    }

    user.Update(request.FirstName, request.LastName);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
