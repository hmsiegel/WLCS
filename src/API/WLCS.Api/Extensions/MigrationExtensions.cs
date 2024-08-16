// <copyright file="MigrationExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

internal static class MigrationExtensions
{
  internal static void ApplyMigrations(this IApplicationBuilder app)
  {
    using IServiceScope scope = app.ApplicationServices.CreateScope();

    ApplyMigration<CompetitionsDbContext>(scope);
    ApplyMigration<AdministrationDbContext>(scope);
    ApplyMigration<AthletesDbContext>(scope);
  }

  private static void ApplyMigration<TDbContext>(IServiceScope scope)
      where TDbContext : DbContext
  {
    using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

    context.Database.Migrate();
  }
}
