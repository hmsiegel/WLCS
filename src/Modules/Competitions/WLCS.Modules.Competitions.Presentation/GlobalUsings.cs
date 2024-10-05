// <copyright file="GlobalUsings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

global using System.Reflection;

global using FastEndpoints;

global using Mapster;

global using MediatR;

global using Microsoft.AspNetCore.Http;

global using WLCS.Common.Application.EventBus;
global using WLCS.Common.Application.Exceptions;
global using WLCS.Common.Presentation.Results;
global using WLCS.Modules.Athletes.IntegrationEvents;
global using WLCS.Modules.Competitions.Application.Athletes.Commands.AddAthleteToMeet;
global using WLCS.Modules.Competitions.Application.Athletes.Commands.CreateAthlete;
global using WLCS.Modules.Competitions.Application.Athletes.Commands.RemoveAthleteFromMeet;
global using WLCS.Modules.Competitions.Application.Competitions.Commands.AddAthleteToCompetition;
global using WLCS.Modules.Competitions.Application.Competitions.Commands.CreateCompetition;
global using WLCS.Modules.Competitions.Application.Competitions.Commands.RemoveCompetitionFromMeet;
global using WLCS.Modules.Competitions.Application.Competitions.Commands.UpdateCompetition;
global using WLCS.Modules.Competitions.Application.Meets.Commands.CreateMeet;
global using WLCS.Modules.Competitions.Application.Meets.Queries;
global using WLCS.Modules.Competitions.Application.Meets.Queries.GetMeet;
global using WLCS.Modules.Competitions.Application.Meets.Queries.GetMeets;
global using WLCS.Modules.Competitions.Application.Platforms.Commands.CreatePlatform;
global using WLCS.Modules.Competitions.Application.Platforms.Commands.RemovePlatformFromMeet;
global using WLCS.Modules.Competitions.Application.Platforms.Commands.UpdatePlatform;
global using WLCS.Modules.Competitions.Contracts.Competitions;
global using WLCS.Modules.Competitions.Contracts.Meets;
global using WLCS.Modules.Competitions.Contracts.Platforms;
