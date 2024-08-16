// <copyright file="RegisterUserCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;

internal sealed class RegisterUserCommandHandler(
  IUserRepository userRepository,
  IUnitOfWork unitOfWork)
  : ICommandHandler<RegisterUserCommand, Guid>
{
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
  {
    var user = User.Create(
        request.Email,
        request.FirstName,
        request.LastName);

    _userRepository.Add(user);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return user.Id;
  }
}
