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
      return Result.Failure(UserErrors.NotFound(request.UserId));
    }

    var firstNameResult = FirstName.Create(request.FirstName);
    var lastNameResult = LastName.Create(request.LastName);

    user.Update(firstNameResult.Value, lastNameResult.Value);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    _userRepository.Update(user);

    return Result.Success();
  }
}
