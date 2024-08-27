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
    var emailResult = Email.Create(request.Email);

    if (emailResult.IsFailure)
    {
      return Result.Failure<Guid>(emailResult.Errors);
    }

    var firstNameResult = FirstName.Create(request.FirstName);
    var lastNameResult = LastName.Create(request.LastName);

    if (!await _userRepository.IsEmailUniqueAsync(emailResult.Value, cancellationToken))
    {
      return Result.Failure<Guid>(UserErrors.EmailAlreadyInUse);
    }

    var user = User.Create(
        emailResult.Value,
        firstNameResult.Value,
        lastNameResult.Value);

    _userRepository.Add(user);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return user.Id.Value;
  }
}
