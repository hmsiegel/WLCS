// <copyright file="GetUserQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUser;

/// <summary>
/// Gets a user by their Id.
/// </summary>
/// <param name="UserId">The user's Id.</param>
public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;
