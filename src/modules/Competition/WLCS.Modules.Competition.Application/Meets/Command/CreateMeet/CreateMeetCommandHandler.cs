// <copyright file="CreateMeetCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Application.Meets.Command.CreateMeet;

/// <summary>
/// The handler for the <see cref="CreateMeetCommand"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CreateMeetCommandHandler"/> class.
/// </remarks>
/// <param name="meetRepository">An instance of the meet repositoyr.</param>
/// <param name="unitOfWork">An instance of the unit of work.</param>
internal sealed class CreateMeetCommandHandler(
  IMeetRepository meetRepository,
  IUnitOfWork unitOfWork)
   : ICommandHandler<CreateMeetCommand, Guid>
{
  private readonly IMeetRepository _meetRepository = meetRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  /// <summary>
  /// Handles the <see cref="CreateMeetCommand"/>.
  /// </summary>
  /// <param name="request">The <see cref="CreateMeetCommand"/>.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>The unique identifier of the meet.</returns>
  public async Task<Result<Guid>> Handle(CreateMeetCommand request, CancellationToken cancellationToken)
  {
    var meet = Meet.Create(
      request.Name,
      request.Location,
      request.Venue,
      request.StartDate,
      request.EndDate);

    _meetRepository.Add(meet);
    await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

    return meet.Id;
  }
}
