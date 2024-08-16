﻿// <copyright file="UserResponse.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUser;

public sealed record UserResponse(Guid Id, string Email, string FirstName, string LastName);
