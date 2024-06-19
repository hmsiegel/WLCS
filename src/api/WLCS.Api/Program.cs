// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

var builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddEndpointsApiExplorer();

  Assembly[] applicationAssemblies = [
      WLCS.Modules.Competition.Application.AssemblyReference.Application,
    ];

  builder.Services.AddApplication(applicationAssemblies);

  builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Database")!);

  string[] configurations = ["competition"];

  builder.Configuration.AddModuleConfiguration(configurations);

  Assembly[] presentationAssemblies = [
      WLCS.Modules.Competition.Presentation.AssemblyReference.Presentation,
    ];

  builder
    .Services.AddFastEndpoints(o => o.Assemblies =
      presentationAssemblies)
    .AddSwaggerGen();
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

  app
    .UseFastEndpoints()
    .UseSwaggerGen();

  app.Run();
}
