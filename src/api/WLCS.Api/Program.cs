// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddEndpointsApiExplorer();
  builder
    .Services.AddFastEndpoints(o => o.Assemblies =
      [
        WLCS.Modules.Competition.Presentation.AssemblyReference.Presentation,
      ])
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
