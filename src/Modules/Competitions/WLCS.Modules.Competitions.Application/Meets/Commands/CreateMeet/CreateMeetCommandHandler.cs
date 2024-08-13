// <copyright file="CreateMeetCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Commands.CreateMeet;

internal sealed class CreateMeetCommandHandler(
  IMeetRepository meetRepository,
  IUnitOfWork unitOfWork,
  IDateTimeProvider dateTimeProvider)
  : ICommandHandler<CreateMeetCommand, Guid>
{
  private readonly IMeetRepository _meetRepository = meetRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

  public async Task<Result<Guid>> Handle(CreateMeetCommand request, CancellationToken cancellationToken)
  {
    if (request.StartDate < _dateTimeProvider.Today)
    {
      return Result.Failure<Guid>(MeetErrors.StartDateIsInThePast);
    }

    var result = Meet.Create(
      request.Name,
      request.Location,
      request.Venue,
      request.StartDate,
      request.EndDate);

    if (result.IsFailure)
    {
      return Result.Failure<Guid>(result.Error);
    }

    _meetRepository.Add(result.Value);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return result.Value.Id;
  }
}
