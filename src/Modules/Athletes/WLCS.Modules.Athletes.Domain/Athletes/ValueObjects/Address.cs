// <copyright file="Address.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes.ValueObjects;

public sealed record Address(
  string Street1,
  string? Street2,
  string? Street3,
  string City,
  string State,
  string ZipCode,
  string Country);
