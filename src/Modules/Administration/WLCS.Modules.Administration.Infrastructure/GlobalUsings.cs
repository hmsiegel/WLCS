// <copyright file="GlobalUsings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

global using System.Data;
global using System.Data.Common;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Text.Json.Serialization;

global using Dapper;

global using MassTransit;

global using MediatR;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore.Migrations;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;

global using Newtonsoft.Json;

global using Quartz;

global using SmartEnum.EFCore;

global using WLCS.Common.Application.Authorization;
global using WLCS.Common.Application.Clock;
global using WLCS.Common.Application.Data;
global using WLCS.Common.Application.EventBus;
global using WLCS.Common.Application.Extensions;
global using WLCS.Common.Application.Messaging;
global using WLCS.Common.Domain;
global using WLCS.Common.Infrastructure.Inbox;
global using WLCS.Common.Infrastructure.Outbox;
global using WLCS.Common.Infrastructure.Serialization;
global using WLCS.Common.Presentation.Endpoints;
global using WLCS.Modules.Administration.Application.Abstractions.Data;
global using WLCS.Modules.Administration.Application.Abstractions.Identity;
global using WLCS.Modules.Administration.Application.Abstractions.Users;
global using WLCS.Modules.Administration.Application.Users.Queries.GetUserPermissions;
global using WLCS.Modules.Administration.Domain.Users;
global using WLCS.Modules.Administration.Domain.Users.ValueObjects;
global using WLCS.Modules.Administration.Infrastructure.Authorization;
global using WLCS.Modules.Administration.Infrastructure.Database;
global using WLCS.Modules.Administration.Infrastructure.Identity;
global using WLCS.Modules.Administration.Infrastructure.Inbox;
global using WLCS.Modules.Administration.Infrastructure.Outbox;
global using WLCS.Modules.Administration.Infrastructure.Users;

global using LoggerExtensions = WLCS.Common.Application.Extensions.LoggerExtensions;
