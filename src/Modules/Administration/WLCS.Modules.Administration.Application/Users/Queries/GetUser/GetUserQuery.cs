// <copyright file="GetUserQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUser;

public sealed record GetUserQuery(Guid UserId) : IQuery<GetUserResponse>;
