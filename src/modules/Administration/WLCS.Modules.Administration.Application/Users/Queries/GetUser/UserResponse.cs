// <copyright file="UserResponse.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUser;

/// <summary>
/// A user response.
/// </summary>
/// <param name="Id">The unique identifier.</param>
/// <param name="FirstName">The first name of the user.</param>
/// <param name="LastName">The last name of the user.</param>
/// <param name="Email">The email of the user.</param>
public sealed record UserResponse(Guid Id, string FirstName, string LastName, string Email);
