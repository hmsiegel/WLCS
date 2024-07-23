// <copyright file="MigrationExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Modules.Competitions.Api.Database;

namespace WLCS.Api.Extensions;

internal static class MigrationExtensions
{
  internal static void ApplyMigrations(this IApplicationBuilder app)
  {
    using IServiceScope scope = app.ApplicationServices.CreateScope();

    ApplyMigration<CompetitionsDbContext>(scope);
  }

  private static void ApplyMigration<TDbContext>(IServiceScope scope)
      where TDbContext : DbContext
  {
    using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

    context.Database.Migrate();
  }
}
