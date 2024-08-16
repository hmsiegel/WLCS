// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

var builder = WebApplication.CreateBuilder(args);
{
  builder.Host.UseSerilog((context, loggerConfiguration)
    => loggerConfiguration.ReadFrom.Configuration(context.Configuration));

  builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
  builder.Services.AddProblemDetails();

  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerDocument();

  Assembly[] applicationAssemblies =
  [
    WLCS.Modules.Competitions.Application.AssemblyReference.Assembly,
    WLCS.Modules.Administration.Application.AssemblyReference.Assembly,
    WLCS.Modules.Athletes.Application.AssemblyReference.Assembly
  ];

  Assembly[] presentationAssemblies =
  [
    WLCS.Modules.Competitions.Presentation.AssemblyReference.Assembly,
    WLCS.Modules.Administration.Presentation.AssemblyReference.Assembly,
    WLCS.Modules.Athletes.Presentation.AssemblyReference.Assembly
  ];

  builder.Services.AddApplication(applicationAssemblies);
  builder.Services.AddFastEndpoints(opt =>
    {
      opt.Assemblies = presentationAssemblies;
    });

  var databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
  var redisConnectionString = builder.Configuration.GetConnectionString("Cache")!;

  builder.Services.AddInfrastructure(
    databaseConnectionString,
    redisConnectionString);

  builder.Configuration.AddModuleConfiguration(["competitions", "administration", "athletes"]);

  builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString);

  builder.Services.AddCompetitionModule(builder.Configuration);
  builder.Services.AddAdministrationModule(builder.Configuration);
  builder.Services.AddAthletesModules(builder.Configuration);
}

var app = builder.Build();
{
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
  }

  app.UseFastEndpoints()
     .UseSwaggerGen();

  app.MapHealthChecks("health", new HealthCheckOptions
  {
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
  });

  app.UseSerilogRequestLogging();

  app.UseExceptionHandler();

  app.Run();
}
