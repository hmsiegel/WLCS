// <copyright file="GetMeetsQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Application.Meets.Queries.GetMeets;

/// <summary>
/// Handler for <see cref="GetMeetsQuery"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetMeetsQueryHandler"/> class.
/// </remarks>
/// <param name="meetRepository">An instance of the meet repository.</param>
internal sealed class GetMeetsQueryHandler(IMeetRepository meetRepository)
        : IQueryHandler<GetMeetsQuery, IReadOnlyCollection<MeetResponse>>
{
  private readonly IMeetRepository _meetRepository = meetRepository;

  /// <inheritdoc/>
  public async Task<Result<IReadOnlyCollection<MeetResponse>>> Handle(
    GetMeetsQuery request,
    CancellationToken cancellationToken)
  {
    var meets = await _meetRepository.GetAll(cancellationToken);

    var result = meets.Select(x => new MeetResponse
    {
      Id = x.Id,
      Name = x.Name,
      Venue = x.Venue,
      StartDate = x.StartDate,
      EndDate = x.EndDate,
      Location = x.Location,
    }).ToList();

    return result;
  }
}
