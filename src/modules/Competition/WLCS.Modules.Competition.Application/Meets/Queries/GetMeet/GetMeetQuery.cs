// <copyright file="GetMeetQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Application.Meets.Queries.GetMeet;

/// <summary>
/// The get meet query.
/// </summary>
/// <param name="MeetId">The unique identifier of the meet.</param>
public sealed record GetMeetQuery(Guid MeetId) : IRequest<MeetResponse>;
