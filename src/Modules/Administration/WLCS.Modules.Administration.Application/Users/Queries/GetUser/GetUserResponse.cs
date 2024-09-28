// <copyright file="GetUserResponse.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUser;

public sealed record GetUserResponse(Guid Id, string Email, string FirstName, string LastName);
