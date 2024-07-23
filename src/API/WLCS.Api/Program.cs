// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();

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

  app.Run();
}
