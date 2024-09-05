// <copyright file="CredentialRepresentation.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

internal sealed record CredentialRepresentation(
  string Type,
  string Value,
  bool Temporary);
