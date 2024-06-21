// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
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

  builder.Services.AddEndpointsApiExplorer();

  Assembly[] applicationAssemblies = [
      WLCS.Modules.Competition.Application.AssemblyReference.Application,
    ];

  builder.Services.AddApplication(applicationAssemblies);

  var databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
  var redisConnectionString = builder.Configuration.GetConnectionString("Cache")!;

  builder.Services.AddInfrastructure(
    databaseConnectionString,
    redisConnectionString);

  string[] configurations = ["competition"];

  builder.Configuration.AddModuleConfiguration(configurations);

  Assembly[] presentationAssemblies = [
      WLCS.Modules.Competition.Presentation.AssemblyReference.Presentation,
    ];

  builder
    .Services.AddFastEndpoints(o => o.Assemblies =
      presentationAssemblies)
    .AddSwaggerGen();

  builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString);

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

  app
    .UseFastEndpoints()
    .UseSwaggerGen();

  app.MapHealthChecks("health", new HealthCheckOptions
  {
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
  });

  app.UseSerilogRequestLogging();

  app.UseExceptionHandler();

  app.Run();
}
