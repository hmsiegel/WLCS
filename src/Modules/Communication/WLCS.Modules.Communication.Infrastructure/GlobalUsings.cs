﻿// <copyright file="GlobalUsings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
global using System.Data;
global using System.Data.Common;

global using Dapper;

global using MassTransit;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Migrations;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;

global using Newtonsoft.Json;

global using Quartz;

global using SmartEnum.EFCore;

global using WLCS.Common.Application.Clock;
global using WLCS.Common.Application.Data;
global using WLCS.Common.Application.EventBus;
global using WLCS.Common.Application.Messaging;
global using WLCS.Common.Domain;
global using WLCS.Common.Infrastructure.Inbox;
global using WLCS.Common.Infrastructure.Outbox;
global using WLCS.Common.Infrastructure.Serialization;
global using WLCS.Modules.Communication.Application.Abstractions.Data;
global using WLCS.Modules.Communication.Infrastructure.Database;
global using WLCS.Modules.Communication.Infrastructure.Inbox;
global using WLCS.Modules.Communication.Infrastructure.Outbox;

global using LoggerExtensions = WLCS.Common.Application.Extensions.LoggerExtensions;