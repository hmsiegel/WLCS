// <copyright file="CreateMeetCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using MeetName = WLCS.Modules.Competitions.Domain.Meets.ValueObjects.MeetName;

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

    var nameResult = MeetName.Create(request.Name);
    var venueResult = Venue.Create(request.Venue);
    var locationResult = Location.Create(request.City, request.State);

    var result = Meet.Create(
      nameResult.Value,
      locationResult.Value,
      venueResult.Value,
      request.StartDate,
      request.EndDate);

    if (result.IsFailure)
    {
      return Result.Failure<Guid>(result.Errors);
    }

    _meetRepository.Add(result.Value);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return result.Value.Id.Value;
  }
}
