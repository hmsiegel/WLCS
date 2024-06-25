// <copyright file="CredentialRepresentation.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

/// <summary>
/// Represents the <see cref="CredentialRepresentation"/> record.
/// </summary>
/// <param name="Type">The type of the credential.</param>
/// <param name="Value">The value of the credential.</param>
/// <param name="Temporary">Whether or not the credential is temporary.</param>
internal sealed record CredentialRepresentation(string Type, string Value, bool Temporary);
