// <copyright file="UpdateUserCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.UpdateUser;

/// <summary>
/// The handler for the <see cref="UpdateUserCommand"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UpdateUserCommandHandler"/> class.
/// </remarks>
/// <param name="userRepository">The user repository.</param>
/// <param name="unitOfWork">The unit of work class.</param>
internal sealed class UpdateUserCommandHandler(
  IUserRepository userRepository,
  IUnitOfWork unitOfWork)
  : ICommandHandler<UpdateUserCommand>
{
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  /// <inheritdoc/>
  public async Task<Result> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetAsync(command.UserId, cancellationToken)
      .ConfigureAwait(false);

    if (user is null)
    {
      return Result.NotFound("User not found");
    }

    user.Update(command.FirstName, command.LastName);

    await _unitOfWork.SaveChangesAsync(cancellationToken)
      .ConfigureAwait(false);

    return Result.Success();
  }
}
