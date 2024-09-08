// <copyright file="IEndpoint.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Presentation.Endpoints;

public interface IEndpoint
{
  void MapEndpoint(IEndpointRouteBuilder app);
}
