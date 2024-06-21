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
internal sealed class RegisterUserCommandHandler(
  IUserRepository userRepository,
  IUnitOfWork unitOfWork)
  : ICommandHandler<RegisterUserCommand, Guid>
{
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  /// <inheritdoc/>
  public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
  {
    var user = User.Create(
      command.Email,
      command.FirstName,
      command.LastName);

    _userRepository.Add(user);

    await _unitOfWork.SaveChangesAsync(cancellationToken)
      .ConfigureAwait(false);

    return Result.Success(user.Id);
  }
}
