// <copyright file="UpdateUserRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Contracts.Users;

public sealed record UpdateUserRequest(string FirstName, string LastName);
