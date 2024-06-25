// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
using FastEndpoints.Security;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
  .CreateLogger();

logger.Information("Starting application.");

var builder = WebApplication.CreateBuilder(args);
{
  builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

  builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
  builder.Services.AddProblemDetails();

  Assembly[] applicationAssemblies = [
      WLCS.Modules.Competition.Application.AssemblyReference.Application,
      WLCS.Modules.Administration.Application.AssemblyReference.Application,
    ];

  builder.Services.AddApplication(applicationAssemblies);

  var databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
  var redisConnectionString = builder.Configuration.GetConnectionString("Cache")!;

  builder.Services.AddInfrastructure(
    databaseConnectionString,
    redisConnectionString);

  Assembly[] presentationAssemblies = [
      WLCS.Modules.Competition.Presentation.AssemblyReference.Presentation,
      WLCS.Modules.Administration.Presentation.AssemblyReference.Presentation,
    ];

  builder
    .Services.AddFastEndpoints(o => o.Assemblies =
      presentationAssemblies)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

  string[] configurations = ["competition", "administration"];

  builder.Configuration.AddModuleConfiguration(configurations);

  builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString);

  builder.Services.AddAdministrationModule(builder.Configuration, logger);
  builder.Services.AddCompetitionModule(builder.Configuration, logger);
}

var app = builder.Build();
{
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
  }

  app.MapHealthChecks("health", new HealthCheckOptions
  {
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
  });

  app.UseSerilogRequestLogging();
  app.UseExceptionHandler();

  app.UseAuthentication()
    .UseAuthorization();

  app
    .UseFastEndpoints()
    .UseSwaggerGen();

  app.Run();
}
