// <copyright file="MigrationExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

/// <summary>
/// Contains extension methods for migrations.
/// </summary>
internal static class MigrationExtensions
{
  /// <summary>
  /// Applies the migrations.
  /// </summary>
  /// <param name="app">The IApplicationBuilder instatnce.</param>
  internal static void ApplyMigrations(this IApplicationBuilder app)
  {
    using var scope = app.ApplicationServices.CreateScope();
    ApplyMigration<CompetitionsDbContext>(scope);
  }

  private static void ApplyMigration<T>(IServiceScope scope)
    where T : DbContext
  {
    using var context = scope.ServiceProvider.GetRequiredService<T>();
    context.Database.Migrate();
  }
}
