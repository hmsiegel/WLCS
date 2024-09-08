// <copyright file="GlobalUsings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

global using System.Reflection;

global using MassTransit;

global using MediatR;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Routing;

global using WLCS.Common.Application.Exceptions;
global using WLCS.Common.Presentation.Endpoints;
global using WLCS.Common.Presentation.Results;
global using WLCS.Modules.Athletes.IntegrationEvents;
global using WLCS.Modules.Competitions.Application.Athletes.Commands.CreateAthlete;
global using WLCS.Modules.Competitions.Application.Competitions.Commands.AddAthleteToCompetition;
global using WLCS.Modules.Competitions.Application.Competitions.Commands.CreateCompetition;
global using WLCS.Modules.Competitions.Application.Meets.Commands.AddAthleteToMeet;
global using WLCS.Modules.Competitions.Application.Meets.Commands.CreateMeet;
global using WLCS.Modules.Competitions.Application.Meets.Queries.GetMeet;
global using WLCS.Modules.Competitions.Application.Meets.Queries.GetMeets;
