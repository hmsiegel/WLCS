// <copyright file="CreateMeetCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Commands.CreateMeet;

internal sealed class CreateMeetCommandHandler(
  IMeetRepository meetRepository,
  IUnitOfWork unitOfWork)
  : IRequestHandler<CreateMeetCommand, Guid>
{
  private readonly IMeetRepository _meetRepository = meetRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<Guid> Handle(CreateMeetCommand request, CancellationToken cancellationToken)
  {
    var meet = Meet.Create(
      request.Name,
      request.Location,
      request.Venue,
      request.StartDate,
      request.EndDate);

    _meetRepository.Add(meet);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return meet.Id;
  }
}
