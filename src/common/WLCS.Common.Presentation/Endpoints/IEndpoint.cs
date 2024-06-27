// <copyright file="IEndpoint.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Presentation.Endpoints;

/// <summary>
/// An interface for an endpoint.
/// </summary>
public interface IEndpoint
{
  /// <summary>
  /// Map an endpoint.
  /// </summary>
  /// <param name="app">An instance of <see cref="IEndpointRouteBuilder"/>.</param>
  void MapEndpoint(IEndpointRouteBuilder app);
}
