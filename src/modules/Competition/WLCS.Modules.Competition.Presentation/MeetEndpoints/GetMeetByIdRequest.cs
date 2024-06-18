// <copyright file="GetMeetByIdRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Presentation.MeetEndpoints;

/// <summary>
/// The request to get a meet by its ID.
/// </summary>
/// <param name="Id">The unique identifier of the requested meet.</param>
public sealed record GetMeetByIdRequest(Guid Id);
