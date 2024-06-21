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
    using IServiceScope scope = app.ApplicationServices.CreateScope();

    ApplyMigration<AdministrationDbContext>(scope);
    ApplyMigration<CompetitionsDbContext>(scope);
  }

  private static void ApplyMigration<TDbContext>(IServiceScope scope)
    where TDbContext : DbContext
  {
    using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

    context.Database.Migrate();
  }
}
