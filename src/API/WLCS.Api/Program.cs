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
  builder.Services.AddSwaggerGen(options =>
  {
    options.CustomSchemaIds(t => t.FullName?.Replace(
      "+",
      ".",
      StringComparison.InvariantCulture));
  });

  builder.Services.AddApplication([WLCS.Modules.Competitions.Application.AssemblyReference.Assembly]);
  builder.Services.AddFastEndpoints(opt =>
    {
      opt.Assemblies = [WLCS.Modules.Competitions.Presentation.AssemblyReference.Assembly];
    });

  var databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
  var redisConnectionString = builder.Configuration.GetConnectionString("Cache")!;

  builder.Services.AddInfrastructure(
    databaseConnectionString,
    redisConnectionString);

  builder.Configuration.AddModuleConfiguration(["competitions"]);

  builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString);

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

  app.UseFastEndpoints();

  app.MapHealthChecks("health", new HealthCheckOptions
  {
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
  });

  app.UseSerilogRequestLogging();

  app.UseExceptionHandler();

  app.Run();
}
