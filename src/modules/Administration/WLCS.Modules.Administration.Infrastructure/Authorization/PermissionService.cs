// <copyright file="PermissionService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Authorization;

/// <summary>
/// A service to handle permission related operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="PermissionService"/> class.
/// </remarks>
/// <param name="sender">An instance of ISender.</param>
internal sealed class PermissionService(ISender sender) : IPermissionService
{
  private readonly ISender _sender = sender;

  /// <inheritdoc/>
  public async Task<Result<PermissionResponse>> GetUserPermissionsAsync(string identityId)
  {
    return await _sender.Send(new GetUserPermissionsQuery(identityId))
      .ConfigureAwait(false);
  }
}
