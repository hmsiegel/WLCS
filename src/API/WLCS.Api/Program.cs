// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
  builder.Host.UseSerilog((context, loggerConfiguration)
    => loggerConfiguration.ReadFrom.Configuration(context.Configuration));

  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen(options =>
  {
    options.CustomSchemaIds(t => t.FullName?.Replace(
      "+",
      ".",
      StringComparison.InvariantCulture));
  });

  builder.Services.AddApplication([WLCS.Modules.Competitions.Application.AssemblyReference.Assembly]);
  builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Database")!);

  builder.Configuration.AddModuleConfiguration(["competitions"]);

  builder.Services.AddCompetitionModule(builder.Configuration);
}

var app = builder.Build();
{
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
  }

  CompetitionModule.MapEndpoints(app);

  app.UseSerilogRequestLogging();

  app.Run();
}
