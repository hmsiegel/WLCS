// <copyright file="RegisterUserCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;

/// <summary>
/// The handler for the <see cref="RegisterUserCommand"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RegisterUserCommandHandler"/> class.
/// </remarks>
/// <param name="userRepository">The user repository.</param>
/// <param name="unitOfWork">The unit of work class.</param>
/// <param name="identityProviderService">The identity provider service.</param>
internal sealed class RegisterUserCommandHandler(
  IUserRepository userRepository,
  IUnitOfWork unitOfWork,
  IIdentityProviderService identityProviderService)
  : ICommandHandler<RegisterUserCommand, Guid>
{
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IIdentityProviderService _identityProviderService = identityProviderService;

  /// <inheritdoc/>
  public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
  {
    Result<string> result = await _identityProviderService.RegisterUserAsync(
      new UserModel(
        command.Email,
        command.Password,
        command.FirstName,
        command.LastName),
      cancellationToken);

    if (result.IsFailure)
    {
      return Result.Failure<Guid>(result.Error);
    }

    var user = User.Create(
      command.Email,
      command.FirstName,
      command.LastName,
      result.Value);

    _userRepository.Add(user);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return user.Id;
  }
}
